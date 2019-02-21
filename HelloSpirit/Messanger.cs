using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloSpirit
{
    public class Messanger
    {
        public static string PATH = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ProjectATR\HelloSpirit";
        public static readonly string Filepath = PATH + @"\data.json";
    }
}
