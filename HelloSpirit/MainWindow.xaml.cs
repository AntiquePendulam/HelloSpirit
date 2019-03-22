using HelloSpirit.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace HelloSpirit
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private static SpiritWindow SpiritWindow { get; set; }
        private static ConfirmationWindow Confirmation { get; set; }
        public static SettingWindow SettingWindow { get; private set; }
        public static MainWindowViewModel MainViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            SpiritWindow = new SpiritWindow();
            Confirmation = new ConfirmationWindow();

            CloseButton.Click += (a, e) => Close();
            TitleBar.MouseDown += (a, e) => DragMove();
            this.Closing += (a, e) => WindowClose();
            ListAddButton.Click += (a, e) => MainViewModel.Lists.Add(new SpiritListViewModel() { ListTitle = "new List" });

            SettingWindow = new SettingWindow(MainViewModel.Setting);
            if (Messanger.IsAuth)
            {
                SettingWindow.TwitterAuthButton.IsEnabled = false;
                SettingWindow.TwitterAuthButton.Content = "認証済み";
            }
            this.DataContext = MainViewModel;
            Grass.TargetWebView = GrassView;
            Grass.GetGrass(MainViewModel.Setting.GitHubName);
            SettingButton.Click += (a, e) => SettingWindow.Show();
        }

        public void CloseButton_Clicked()
        {
            this.Close();
        }

        private void ListBoxItem_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            var data = (sender as ListBoxItem).DataContext as SpiritViewModel;
            var listbox = FindAncestor<ListBox>( (sender as ListBoxItem) );
            SpiritWindow.Show(data, (listbox.DataContext as SpiritListViewModel).List);
        }

        private void WindowClose()
        {
            SpiritWindow.Close();
            Confirmation.Close();
            SettingWindow.Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var x = (sender as Button).DataContext as SpiritListViewModel;
            var spirit = new SpiritViewModel() { Title = "new Spirit." };
            x.List.Add(spirit);
            SpiritWindow.Show(spirit, x.List);
        }

        private static T FindAncestor<T>(DependencyObject from)
          where T : class
        {
            if (from == null)
            {
                return null;
            }

            T candidate = from as T;
            if (candidate != null)
            {
                return candidate;
            }

            return FindAncestor<T>(VisualTreeHelper.GetParent(from));
        }



        private void ListDelete(object sender, RoutedEventArgs e)
        {
            Confirmation.ShowDialog();

            if (!Confirmation.Accept) return;
            var data = (sender as Button).DataContext as SpiritListViewModel;
            MainViewModel.Lists.Remove(data);
        }
    }
}