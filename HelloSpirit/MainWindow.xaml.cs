using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
using System.IO;

namespace HelloSpirit
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private static AddSpirit AddWindow { get; } = new AddSpirit();
        private static SpiritWindow SpiritWindow { get; } = new SpiritWindow();
        private static MainWindowViewModel MainViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Grass.GetGrass(GrassView);
            CloseButton.Click += (a, e) => Close();
            TitleBar.MouseDown += (a, e) => DragMove();
            this.Closing += (a, e) => WindowClose();


            var data = File.ReadAllBytes(@"./nine.json");
            MainViewModel = MessagePackSerializer.Deserialize<MainWindowViewModel>(data);

            MainViewModel.Lists.ObserveElementPropertyChanged().Subscribe(_ => WriteData());
            MainViewModel.Lists.CollectionChanged += (a,e) => WriteData();

            /*
            var cl = new CheckList("JSONデータ保存", false);
            var cl2 = new CheckList("SpiritWindow", true);
            var cl3 = new CheckList("AddSpiritWindow", false);
            var cl4 = new CheckList("ListBox", true);

            var clc = new ObservableCollection<CheckList>()
            {
                cl,cl2,cl3,cl4
            };

            var sp = new Spirit()
            {
                Title = "HelloSpirit",
                Description = "タスク管理アプリ",
                CheckLists = clc
            };

            var spvm = new SpiritListViewModel()
            {
                ListTitle = "C#:個人開発タスク",
                List = new ObservableCollection<Spirit>() { sp }
            };

            var mwvm = new MainWindowViewModel()
            {
                Lists = new ObservableCollection<SpiritListViewModel>() { spvm }
            };

            var js = MessagePackSerializer.Serialize(mwvm);
            File.WriteAllBytes("./nine.json", js);
            */

            this.DataContext = MainViewModel;
        }

        public void CloseButton_Clicked()
        {
            this.Close();
        }

        private void ListBoxItem_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            var data = (sender as ListBoxItem).DataContext as Spirit;
            SpiritWindow.Show(data);
        }

        private void WindowClose()
        {
            AddWindow.Close();
            SpiritWindow.Close();
        }

        public static void WriteData()
        {
            var js = MessagePackSerializer.Serialize(MainViewModel);
            File.WriteAllBytes("./nine.json", js);
        }
    }
}