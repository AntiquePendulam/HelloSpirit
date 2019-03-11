using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using CoreTweet;
using MessagePack;

namespace HelloSpirit
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        public static readonly string KEY_FILEPATH = Messanger.PATH + @"\keys.json";

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Messanger.Read();
        }
    }
}
