using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloSpirit
{
    public class Spirit
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime LimitDate { get; set; }
        public List<CheckList> CheckLists { get; set; }
    }
}
