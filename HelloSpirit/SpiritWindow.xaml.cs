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
using System.ComponentModel;
using System.Runtime.CompilerServices;
using HelloSpirit.ViewModels;

namespace HelloSpirit
{
    /// <summary>
    /// SpiritWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class SpiritWindow : Window
    {

        private ObservableCollection<SpiritViewModel> Spirits;

        public SpiritWindow()
        {
            InitializeComponent();
            AddCheckList.Click += (a, e) =>
            {
                if ((this.DataContext as SpiritViewModel).CheckLists == null) (this.DataContext as SpiritViewModel).CheckLists = new ObservableCollection<CheckListViewModel>();
                (this.DataContext as SpiritViewModel).CheckLists.Add(new CheckListViewModel());
            };
            DeleteButton.Click += (a, e) =>
            {
                Spirits.Remove(this.DataContext as SpiritViewModel);
                CloseButton_Clicked();
            };
            MouseLeftButtonUp += (a, e) => Keyboard.ClearFocus();
        }
        public void Show(SpiritViewModel data, ObservableCollection<SpiritViewModel> spirits)
        {
            this.DataContext = data;
            this.Spirits = spirits;
            this.Show();
        }


        public void CloseButton_Clicked()
        {
            Messanger.Write();
            this.Hide();
        }

        private void DeleteItem(object sender, RoutedEventArgs e)
        {
            (this.DataContext as SpiritViewModel).CheckLists.Remove( ( (sender as MenuItem).DataContext as CheckListViewModel) );
        }
    }
}
