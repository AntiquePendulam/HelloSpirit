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
using System.Windows.Shapes;

namespace HelloSpirit
{
    /// <summary>
    /// SpiritWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class SpiritWindow : Window
    {
        public SpiritWindow()
        {
            InitializeComponent();
            MouseLeftButtonUp += (a, e) => Keyboard.ClearFocus();
        }
        public void Show(Spirit data)
        {
            this.DataContext = data;
            this.Show();
        }
        public void CloseButton_Clicked()
        {
            this.Hide();
        }
    }
}
