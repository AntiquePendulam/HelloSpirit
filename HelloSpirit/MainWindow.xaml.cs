using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using Reactive.Bindings.Extensions;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using MessagePack;
using HelloSpirit.ViewModels;
using System.IO;

namespace HelloSpirit
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private static SpiritWindow SpiritWindow { get; } = new SpiritWindow();
        private static ConfirmationWindow confirmation = new ConfirmationWindow();
        private static SettingWindow SettingWindow { get; } = new SettingWindow();
        public static MainWindowViewModel MainViewModel { get; set; }

        public MainWindow()
        {
            Messanger.Read();
            InitializeComponent();
            CloseButton.Click += (a, e) => Close();
            TitleBar.MouseDown += (a, e) => DragMove();
            this.Closing += (a, e) => WindowClose();
            ListAddButton.Click += (a, e) => MainViewModel.Lists.Add(new SpiritListViewModel() { ListTitle = "new List" });

            SettingWindow.DataContext = MainViewModel.Setting;
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
            confirmation.Close();
            SettingWindow.Close();
        }
        /*
        public static void WriteData()
        {
            var js = MessagePackSerializer.Serialize(MainViewModel);
            File.WriteAllBytes("./nine.json", js);
        }*/

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
            confirmation.ShowDialog();

            if (!confirmation.Accept) return;
            var data = (sender as Button).DataContext as SpiritListViewModel;
            MainViewModel.Lists.Remove(data);
        }
    }
}