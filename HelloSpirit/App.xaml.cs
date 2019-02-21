﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HelloSpirit
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        public static string PATH = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ProjectATR\HelloSpirit";
        public static readonly string Filepath = PATH + @"\data.json";

        public static string UserName = "AntiqueR";
        public static string GitHubName = "AntiquePendulam";

        private void Application_Startup(object sender, StartupEventArgs e)
        {

        }
    }
}
