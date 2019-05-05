using HelloSpirit.ViewModels;
using MessagePack;
using Newtonsoft.Json;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HelloSpirit
{
    public static class Messanger
    {
        public static string PATH = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ProjectATR\HelloSpirit";
        public static readonly string FILEPATH = PATH + @"\data.json";
        public static readonly string COLOR_FILEPATH = PATH + @"\colorsetting.json";
        public static readonly string KEY_FILEPATH = PATH + @"\key.json";

        private static readonly string LOG_FILE = $@"./{DateTime.Today.ToString("yyyy-MM-dd")}_log.log";

        private static readonly ObservableCollection<SpiritListViewModel> defaultList = new ObservableCollection<SpiritListViewModel>()
        {
            new SpiritListViewModel(){ListTitle = "ToDo"},
            new SpiritListViewModel(){ListTitle = "Working"},
            new SpiritListViewModel(){ListTitle = "Complate"}
        };
        private static readonly MainWindowViewModel defaultViewModel = new MainWindowViewModel() { Lists = defaultList };

        public static HttpClient HttpClient { get; } = new HttpClient() { BaseAddress = new Uri(@"https://hellospirit.azurewebsites.net/") };

        private static readonly SpiritThemeColor Colors = new SpiritThemeColor();

        public static event Action<byte[]> Wrote = null;
        public static event Action Reading = null;

        public static bool IsAuth { get; private set; } = false;

        public static void Read()
        {
            if (File.Exists(FILEPATH))
            {
                var json = File.ReadAllBytes(FILEPATH);
                MainWindow.MainViewModel = MessagePackSerializer.Deserialize<MainWindowViewModel>(json);

                if (MainWindow.MainViewModel == null) MainWindow.MainViewModel = defaultViewModel;
            }
            else MainWindow.MainViewModel = defaultViewModel;

            if (File.Exists(COLOR_FILEPATH))
            {
                var colorJson = File.ReadAllText(COLOR_FILEPATH);
                JsonConvert.DeserializeObject<SpiritThemeColor>(colorJson);
            }
            else ThemeWrite();

            if (File.Exists(KEY_FILEPATH))
            {
                var Key = File.ReadAllBytes(KEY_FILEPATH);
                var strKey = MessagePackSerializer.Deserialize<string>(Key);
                HttpClient.DefaultRequestHeaders.Add("X-ZUMO-AUTH", strKey);
                Reading += async () =>
                {
                    var (model, IsSuccess) = await GetDataAsync();
                    if (IsSuccess) MainWindow.MainViewModel.UpdateViewModel(model);
                };
                IsAuth = true;
            }

            Reading?.Invoke();

            Wrote += async bytes => await PostDataAsync(bytes);

            MainWindow.MainViewModel.Lists.ObserveElementPropertyChanged().Subscribe(_ => Write());
            MainWindow.MainViewModel.Lists.CollectionChanged += (a, e) => Write();
        }

        public static void Write()
        {
            var bytes = MessagePackSerializer.Serialize(MainWindow.MainViewModel);
            if (!Directory.Exists(PATH)) Directory.CreateDirectory(PATH);
            File.WriteAllBytes(FILEPATH, bytes);
            Wrote?.Invoke(bytes);
        }

        public static void ThemeWrite()
        {
            var themeColors = JsonConvert.SerializeObject(Colors, Formatting.Indented);
            File.WriteAllText(COLOR_FILEPATH, themeColors);
        }

        public static async Task<(MainWindowViewModel model,bool IsSuccess)> GetDataAsync()
        {
            using (var fs = new StreamWriter(LOG_FILE, true, Encoding.UTF8))
            {
                await fs.WriteLineAsync($"{DateTime.Now} : GetDataAsync.");
            }

            var key = HttpClient.DefaultRequestHeaders.SingleOrDefault(x => x.Key == "X-ZUMO-AUTH").Value?.SingleOrDefault();
            if (key == null || key == "")
            {
                using (var fs = new StreamWriter(LOG_FILE, true, Encoding.UTF8))
                {
                    await fs.WriteLineAsync($"{DateTime.Now} : GetDataAsync:Key is Null or Empty.");
                }
                return (null, false);
            }
            var res = await HttpClient.GetAsync("api/Spirit");
            if (res.StatusCode == HttpStatusCode.OK)
            {
                var bin =  MessagePackSerializer.Deserialize<MainWindowViewModel>(await res.Content.ReadAsByteArrayAsync());
                using (var fs = new StreamWriter(LOG_FILE, true, Encoding.UTF8))
                {
                    await fs.WriteLineAsync($"{DateTime.Now} : GetDataAsync:Successc.");
                }
                return (bin, true);
            }
            else if(res.StatusCode == HttpStatusCode.NotFound)
            {
                using (var fs = new StreamWriter(LOG_FILE, true, Encoding.UTF8))
                {
                    await fs.WriteLineAsync($"{DateTime.Now} : GetDataAsync:Data Not Found.");
                }
                return (null, true);
            }
            else
            {
                using (var fs = new StreamWriter(LOG_FILE, true, Encoding.UTF8))
                {
                    await fs.WriteLineAsync($"{DateTime.Now} : GetDataAsync : Failed. {await res.Content.ReadAsStringAsync()}");
                }
                return (null, false);
            }
        }

        public static async Task PostDataAsync(byte[] data)
        {
            using (var fs = new StreamWriter(LOG_FILE, true, Encoding.UTF8))
            {
                await fs.WriteLineAsync($"{DateTime.Now} : PostDataAsync.");
            }

            var key = HttpClient.DefaultRequestHeaders.SingleOrDefault(x => x.Key == "X-ZUMO-AUTH").Value?.SingleOrDefault();
            if (key == null || key == "")
            {
                using (var fs = new StreamWriter(LOG_FILE, true, Encoding.UTF8))
                {
                    await fs.WriteLineAsync($"{DateTime.Now} : PostDataAsync : Failed. Header : {key}");
                }
                return;
            }
                
            var content = new ByteArrayContent(data);
            try
            {
                var response = await HttpClient.PostAsync("api/Spirit", content);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    using (var fs = new StreamWriter(LOG_FILE, true, Encoding.UTF8))
                    {
                        await fs.WriteLineAsync($"{DateTime.Now} : PostDataAsync : Failed. HttpStatus isn't OK");
                    }
                    Wrote = null;
                }
                else
                {
                    var array = await response.Content.ReadAsByteArrayAsync();
                    //var arStr = array.Select(x => x.ToString()).Aggregate((a, b) => $"{a} {b}");
                    using (var fs = new StreamWriter(LOG_FILE, true, Encoding.UTF8))
                    {
                        await fs.WriteLineAsync($"{DateTime.Now} : PostDataAsync : Success! : {array.Length}");
                    }
                }
            }
            catch   
            {
                MessageBox.Show("サーバー同期中にエラーが発生しました。Twitterの再認証を行ってみてください。");
                using (var fs = new StreamWriter(LOG_FILE, true, Encoding.UTF8))
                {
                    await fs.WriteLineAsync($"{DateTime.Now} : PostDataAsync : Failed. Exception");
                }
                Wrote = null;
            }
        }
    }
}
