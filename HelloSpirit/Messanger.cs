using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using MessagePack;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using HelloSpirit.ViewModels;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using System.Windows;

namespace HelloSpirit
{
    public static class Messanger
    {
        public static string PATH = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ProjectATR\HelloSpirit";
        public static readonly string FILEPATH = PATH + @"\data.json";
        public static readonly string COLOR_FILEPATH = PATH + @"\colorsetting.json";
        public static readonly string KEY_FILEPATH = PATH + @"\key.json";

        private static readonly ObservableCollection<SpiritListViewModel> defaultList = new ObservableCollection<SpiritListViewModel>()
        {
            new SpiritListViewModel(){ListTitle = "ToDo"},
            new SpiritListViewModel(){ListTitle = "Working"},
            new SpiritListViewModel(){ListTitle = "Complate"}
        };
        private static readonly MainWindowViewModel defaultViewModel = new MainWindowViewModel() { Lists = defaultList };

        public static HttpClient HttpClient { get; } = new HttpClient() { BaseAddress = new Uri(@"https://hellospiritapi.azurewebsites.net/") };

        private static readonly SpiritThemeColor Colors = new SpiritThemeColor();

        public static event Action<byte[]> Wrote = null;
        public static event Action Reading = null;

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
                Wrote += async bytes => await PostDataAsync(bytes);
                Reading += async () => await GetDataAsync();
            }

            Reading?.Invoke();

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

        public static async Task<MainWindowViewModel> GetDataAsync()
        {
            var key = HttpClient.DefaultRequestHeaders.SingleOrDefault(x => x.Key == "X-ZUMO-AUTH").Value?.SingleOrDefault();
            if (key == null || key == "") return null;
            var res = await HttpClient.GetAsync("api/Spirit");
            if (res.StatusCode == HttpStatusCode.OK)
            {
                var binStr = Convert.FromBase64String(await res.Content.ReadAsStringAsync());
                var bin =  MessagePackSerializer.Deserialize<MainWindowViewModel>(binStr);
                return bin;
            }
            else return null;
        }

        public static async Task PostDataAsync(byte[] data)
        {
            if (HttpClient.DefaultRequestHeaders.SingleOrDefault(x => x.Key == "X-ZUMO-AUTH").Value == null) return;
            var content = new ByteArrayContent(data);
            try
            {
                var response = await HttpClient.PostAsync("api/Spirit", content);

                if (!response.Content.ReadAsByteArrayAsync().Equals(data))
                {
                    MessageBox.Show("サーバーと続できませんでした。Twitterの再認証を行ってみてください。");
                    Wrote = null;
                }
            }
            catch
            {
                MessageBox.Show("サーバー同期中にエラーが発生しました。Twitterの再認証を行ってみてください。");
                Wrote = null;
            }
        }
    }
}
