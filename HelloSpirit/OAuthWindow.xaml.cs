using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Reactive.Linq;
using CoreTweet;
using Newtonsoft.Json;
using MessagePack;
using System.Net.Http;
using System.IO;

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

            Observable.FromEventPattern<KeyEventArgs>(CodeTextBox, "KeyDown")
                .Where(x => x.EventArgs.Key == Key.Enter && CodeTextBox.Text.Length == 7)
                .Subscribe(async _ =>
                {
                    //try
                    //{
                        var tokens = await Session?.GetTokensAsync(CodeTextBox.Text);
                        var authToken = await ConnectAzureAsync(tokens);
                        Messanger.HttpClient.DefaultRequestHeaders.Clear();
                        Messanger.HttpClient.DefaultRequestHeaders.Add("X-ZUMO-AUTH", authToken);
                        var getData = await Messanger.GetDataAsync();
                        if (getData != null)
                        {
                            MainWindow.MainViewModel.UpdateViewModel(getData);
                            Messanger.Wrote += async bytes => await Messanger.PostDataAsync(bytes);
                            using (var fs = new FileStream(Messanger.KEY_FILEPATH, FileMode.Create, FileAccess.Write))
                            {
                                await MessagePackSerializer.SerializeAsync(fs, authToken);
                            }
                        }
                        else
                        {
                            Messanger.HttpClient.DefaultRequestHeaders.Clear();
                        }
                    //}
                    //catch { Messanger.HttpClient.DefaultRequestHeaders.Clear(); }
                    this.Hide();
                });
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
