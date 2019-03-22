using HelloSpirit.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace HelloSpirit
{
    /// <summary>
    /// Setting.xaml の相互作用ロジック
    /// </summary>
    public partial class SettingWindow : Window
    {
        private static OAuthWindow AuthWindow = new OAuthWindow();
        private SettingViewModel buffer;

        public SettingWindow(SettingViewModel viewModel)
        {
            InitializeComponent();
            MouseLeftButtonUp += (a, e) => Keyboard.ClearFocus();
            ThemeButton.Click += (a, e) => Messanger.ThemeWrite();
            TwitterAuthButton.Click += (a, e) => AuthWindow.ShowDialog();
            this.Closing += (a, e) => AuthWindow.Close();
            this.DataContext = viewModel;
            buffer = new SettingViewModel() { GitHubName = viewModel.GitHubName, UserName=viewModel.UserName};
        }

        public void CloseButton_Clicked()
        {
            var data = this.DataContext as SettingViewModel;
            if(!Equals(data.UserName, buffer.UserName) || !Equals(data.GitHubName, buffer.GitHubName))
            {
                Messanger.Write();
                if(!Equals(data.GitHubName, buffer.GitHubName)) Grass.GetGrass(data.GitHubName);
            }
            this.Hide();
        }
    }
}
