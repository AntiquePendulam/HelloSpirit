﻿using System;
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

            var checklist1 = new CheckList
            {
                Title = "ButtonTextの色をいじる",
                IsFinished = true
            };
            var checklist2 = new CheckList
            {
                Title = "たこやきたべる",
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
            var checklist5 = new CheckList
            {
                Title = "魂の平穏",
                IsFinished = true
            };
            var checklist6 = new CheckList
            {
                Title = "アドレナリン",
                IsFinished = true
            };

            ObservableCollection<CheckList> lister = new ObservableCollection<CheckList>
            {
                checklist1,
                checklist2,
                checklist3,
                checklist4
            };

            ObservableCollection<CheckList> lister2 = new ObservableCollection<CheckList>
            {
                checklist1,
                checklist2,
                checklist3,
                checklist4,
                checklist5,
                checklist6
            };

            var spirit = new Spirit(lister)
            {
                Title = "ListBoxの中身クリック表示",
                Description = "はいわろたあ",
                LimitDate = DateTime.Now,
            };
            var spirit2 = new Spirit(lister)
            {
                Title = "Add機能追加",
                Description = "はいたこやき",
                LimitDate = DateTime.UtcNow,
            };
            var spirit3 = new Spirit(lister)
            {
                Title = "Jsonファイル化",
                Description = "TAKOOOOOOOOOOOO!",
                LimitDate = null,
            };
            var spirit4 = new Spirit(lister2)
            {
                Title = "期限機能追加",
                Description = "YRAHH!",
                LimitDate = null,
            };

            var list = new ObservableCollection<Spirit>
            {
                spirit,
                spirit2,
                spirit4
            };
            var list2 = new ObservableCollection<Spirit>
            {
                spirit3
            };

            var Offi = new SpiritListViewModel()
            {
                ListTitle = "C#",
                List = list
            };
            var Offi2 = new SpiritListViewModel()
            {
                ListTitle = "Go langもしなきゃ",
                List = list2
            };
            var ff = new MainWindowViewModel()
            {
                Lists = new ObservableCollection<SpiritListViewModel>()
                {
                    Offi,Offi2
                }
            };

            this.DataContext = ff;
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