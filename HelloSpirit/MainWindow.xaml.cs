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

namespace HelloSpirit
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TitleBar.MouseLeftButtonDown += (a, e) => DragMove();
            CloseButton.Click += (a, e) => this.Close();
            Grass.GetGrass(GrassView);
            Label.DataContext = TimeText();
        }

        public static string TimeText()
        {
            var time = DateTime.Now.Hour;
            return $"Hello! {App.UserName}.";
        }

        private void ListTitle_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
