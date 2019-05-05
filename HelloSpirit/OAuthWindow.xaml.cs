using CoreTweet;
using MessagePack;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HelloSpirit
{
    /// <summary>
    /// OAuthWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class OAuthWindow : Window
    {

        private OAuth.OAuthSession Session;

        public OAuthWindow()
        {
            InitializeComponent();
            this.Loaded += async (a, e) =>
            {
                Session = await OAuth.AuthorizeAsync(AuthKeys.consumerKey, AuthKeys.consumerSecert);
                Process.Start(Session.AuthorizeUri.ToString());
            };

            Observable.FromEventPattern<RoutedEventArgs>(Auth, "Click")
                .Where(_ => CodeTextBox.Text.Length == 7)
                .Subscribe(async _ => await SetAuthAsync());

            Observable.FromEventPattern<KeyEventArgs>(CodeTextBox, "KeyDown")
                .Where(x => x.EventArgs.Key == Key.Enter && CodeTextBox.Text.Length == 7)
                .Subscribe(async _ => await SetAuthAsync());
        }

        private async Task SetAuthAsync()
        {
            this.Label.Content = "認証中...";
            CodeTextBox.IsEnabled = false;
            bool isSuc = false;
            try
            {
                var tokens = await Session?.GetTokensAsync(CodeTextBox.Text);
                var authToken = await ConnectAzureAsync(tokens);
                Messanger.HttpClient.DefaultRequestHeaders.Clear();
                Messanger.HttpClient.DefaultRequestHeaders.Add("X-ZUMO-AUTH", authToken);

                var (model, IsSuccess) = await Messanger.GetDataAsync();
                isSuc = IsSuccess;
                if (IsSuccess && model != null)
                {
                    MainWindow.MainViewModel.UpdateViewModel(model);
                    Messanger.Wrote += async bytes => await Messanger.PostDataAsync(bytes);

                    using (var fs = new FileStream(Messanger.KEY_FILEPATH, FileMode.Create, FileAccess.Write))
                    {
                        await MessagePackSerializer.SerializeAsync(fs, authToken);
                    }
                }
                else if(IsSuccess)
                {
                    var m = MessagePackSerializer.Serialize(MainWindow.MainViewModel);
                    await Messanger.PostDataAsync(m);
                    using (var fs = new FileStream(Messanger.KEY_FILEPATH, FileMode.Create, FileAccess.Write))
                    {
                        await MessagePackSerializer.SerializeAsync(fs, authToken);
                    }
                }
                else Messanger.HttpClient.DefaultRequestHeaders.Clear();
            }
            catch
            {
                this.Label.Content = "認証失敗";
                CodeTextBox.IsEnabled = true;
                return;
            }
            CodeTextBox.IsEnabled = true;
            if (isSuc)
            {
                this.Label.Content = "認証成功";
                MainWindow.SettingWindow.TwitterAuthButton.IsEnabled = false;
                MainWindow.SettingWindow.TwitterAuthButton.Content = "認証済み";
            }
            else
            {
                this.Label.Content = "認証失敗";
            }
            await Task.Delay(1500);
            this.Label.Content = "Webブラウザでログイン後、表示されるコードを入力して下さい。";
            this.Hide();
        }

        private async Task<string> ConnectAzureAsync(Tokens tokens)
        {
            var tokenData = new { access_token = tokens.AccessToken, access_token_secret = tokens.AccessTokenSecret };
            var json = JsonConvert.SerializeObject(tokenData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Messanger.HttpClient.PostAsync(".auth/login/twitter", content);
            var resData = JsonConvert.DeserializeObject<AuthData>(await response.Content.ReadAsStringAsync());
            return resData.authenticationToken;
        }

        public class AuthData
        {
            public string authenticationToken;
            public User user;

            public class User
            {
                public string userId;
            }
        }
    }
}
