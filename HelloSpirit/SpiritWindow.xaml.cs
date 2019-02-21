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
using System.Collections.ObjectModel;
using System.Windows.Shapes;

namespace HelloSpirit
{
    /// <summary>
    /// SpiritWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class SpiritWindow : Window
    {

        private ObservableCollection<Spirit> Spirits;

        public SpiritWindow()
        {
            InitializeComponent();
            DeleteButton.Click += (a, e) =>
            {
                Spirits.Remove(this.DataContext as Spirit);
                CloseButton_Clicked();
            };
            MouseLeftButtonUp += (a, e) => Keyboard.ClearFocus();
        }
        public void Show(Spirit data, ObservableCollection<Spirit> spirits)
        {
            this.DataContext = data;
            this.Spirits = spirits;
            this.Show();
        }
        public void CloseButton_Clicked()
        {
            MainWindow.WriteData();
            this.Hide();
        }

        private void AddCheckList_Click(object sender, RoutedEventArgs e)
        {
            if ((this.DataContext as Spirit).CheckLists == null) (this.DataContext as Spirit).CheckLists = new ObservableCollection<CheckList>() {};
            (this.DataContext as Spirit).CheckLists.Add(new CheckList());
        }

        private void DeleteItem(object sender, RoutedEventArgs e)
        {
            (this.DataContext as Spirit).CheckLists.Remove( ( (sender as MenuItem).DataContext as CheckList) );
        }
    }
}
