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
        private static AddSpirit AddWindow { get; } = new AddSpirit();
        private static SpiritWindow SpiritWindow { get; } = new SpiritWindow();

        public MainWindow()
        {
            InitializeComponent();
            Grass.GetGrass(GrassView);
            CloseButton.Click += (a, e) => Close();
            TitleBar.MouseDown += (a, e) => DragMove();
            this.Closing += (a, e) => WindowClose();
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
    }
}