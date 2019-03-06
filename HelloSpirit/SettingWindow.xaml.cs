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
using HelloSpirit.ViewModels;

namespace HelloSpirit
{
    /// <summary>
    /// Setting.xaml の相互作用ロジック
    /// </summary>
    public partial class SettingWindow : Window
    {
        public SettingWindow()
        {
            InitializeComponent();
            MouseLeftButtonUp += (a, e) => Keyboard.ClearFocus();
            ThemeButton.Click += (a, e) => Messanger.ThemeWrite();
        }

        public void CloseButton_Clicked()
        {
            Messanger.Write();
            var data = this.DataContext as SettingViewModel;
            Grass.GetGrass(data.GitHubName);
            this.Hide();
        }
    }
}
