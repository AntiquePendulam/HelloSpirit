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
    /// ConfirmationWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class ConfirmationWindow : Window
    {
        public bool Accept { get; private set; } = false;

        public ConfirmationWindow()
        {
            InitializeComponent();
            OK.Click += (a, e) => { Accept = true; this.Hide(); };
            Cancel.Click += (a, e) => { Accept = false; this.Hide(); };
        }
    }
}
