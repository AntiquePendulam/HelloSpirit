using AngleSharp.Html;
using AngleSharp.Html.Parser;
using Microsoft.Toolkit.Wpf.UI.Controls;
using System.IO;
using System.Linq;
using System.Net.Http;

namespace HelloSpirit
{
    internal static class Grass
    {
        private const string style = "<style> text { fill: white; font-family: 'Quicksand', sans-serif; font-size: 12px; line-height: 1.5; } </style>";
        private const string errorHtml = "<html> <h1>Couldn't Find Your Contributions.<br>Check Your Setting.</h1> </html>";

        public static WebView TargetWebView {private get; set; }

        private static string nameBuffer = "";

        private static readonly string bg_color = SpiritThemeColor.WindowBackground.Color.ToString().Remove(1,2);

        internal static async void GetGrass(string name)
        {
            if (TargetWebView == null || Equals(nameBuffer, name)) return;
            if (name == null || name == "") name = "AntiquePendulam";
            var client = new HttpClient();
            var a = await client.GetAsync($"https://github.com/users/{name}/contributions");
            var html = await a.Content.ReadAsStringAsync();

            var parser = new HtmlParser();
            var sw = new StringWriter();
            var formatter = new PrettyMarkupFormatter();

            try
            {
                var content = parser.ParseDocument(html).GetElementsByTagName("svg")?.First().OuterHtml;
                string htmlStr;
                if (content == null) htmlStr = errorHtml;
                else htmlStr = $"<html> <link href=\"https://fonts.googleapis.com/css?family=Quicksand\" rel=\"stylesheet\"> {style} <body bgcolor=\"{bg_color}\"> {content} </body> </html>";
                TargetWebView.NavigateToString(htmlStr);
            }
            catch { }

            nameBuffer = name;
        }
    }
}
