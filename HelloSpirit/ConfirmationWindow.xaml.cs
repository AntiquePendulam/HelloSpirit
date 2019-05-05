using System.Windows;

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
