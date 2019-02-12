using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using AngleSharp.Html.Parser;
using System.IO;
using AngleSharp.Html;
using System.Diagnostics;
using Microsoft.Toolkit.Wpf.UI.Controls;

namespace HelloSpirit
{
    internal static class Grass
    {
        private const string style = "<style> text { fill: white; font-family: 'Quicksand', sans-serif; font-size: 12px; line-height: 1.5; } </style>";

        internal static async void GetGrass(WebView view)
        {
            var client = new HttpClient();
            var a = await client.GetAsync($"https://github.com/users/{App.GitHubName}/contributions");
            var html = await a.Content.ReadAsStringAsync();

            var parser = new HtmlParser();
            var sw = new StringWriter();
            var formatter = new PrettyMarkupFormatter();
            var content = parser.ParseDocument(html).GetElementsByTagName("svg").First().OuterHtml;
            var htmlStr = $"<html> <link href=\"https://fonts.googleapis.com/css?family=Quicksand\" rel=\"stylesheet\"> {style} <body bgcolor=\"black\"> {content} </body> </html>";
            view.NavigateToString(htmlStr);
        }
    }
}
