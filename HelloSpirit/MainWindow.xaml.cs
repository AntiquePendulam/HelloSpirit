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

namespace HelloSpirit
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public static AddSpirit AddWindow { get; } = new AddSpirit();

        public MainWindow()
        {
            InitializeComponent();
            TitleBar.MouseLeftButtonDown += (a, e) =>
            {
                DragMove();
                this.WindowState = WindowState.Normal;
            };
            CloseButton.Click += (a, e) => this.Close();
            Grass.GetGrass(GrassView);
            Label.DataContext = TimeText();
            MinimumButton.Click += (a, e) => this.WindowState = WindowState.Minimized;

            var checklist1 = new CheckList
            {
                Title = "Huzakeruna",
                IsFinished = true
            };
            var checklist2 = new CheckList
            {
                Title = "たこやきくいてえ",
                IsFinished = false
            };
            var checklist3 = new CheckList
            {
                Title = "風の中の俺",
                IsFinished = true
            };
            var checklist4 = new CheckList
            {
                Title = "September",
                IsFinished = false
            };

            List<CheckList> lister = new List<CheckList>
            {
                checklist1,
                checklist2,
                checklist3,
                checklist4
            };

            var spirit = new Spirit
            {
                Title = "ワロタ",
                Description = "はいわろたあ",
                LimitDate = null,
                CheckLists = lister
            };
            var spirit2 = new Spirit
            {
                Title = "たこやきたすく",
                Description = "はいたこやき",
                LimitDate = null,
                CheckLists = lister
            };
            var spirit3 = new Spirit
            {
                Title = "たこたこたここ",
                Description = "TAKOOOOOOOOOOOO!",
                LimitDate = null,
                CheckLists = lister
            };

            ObservableCollection<Spirit> list = new ObservableCollection<Spirit>
            {
                spirit,
                spirit2,
                spirit3
            };

            TestList.DataContext = list;
        }

        public static string TimeText()
        {
            var time = DateTime.Now.Hour;
            return $"Hello! {App.UserName}.";
        }

        private void Fie_TextChanged(object sender, TextChangedEventArgs e)
        {
            var t = sender as TextBox;
            Dispatcher.BeginInvoke(new Action(() => MessageBox.Show(t.Text)) );
        }

        //ListBoxitemClick
        private void Spirit_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AddWindow.Show();
        }
    }
}
