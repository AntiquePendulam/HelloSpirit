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
        public DateTime? LimitDate { get; set; }
        public List<CheckList> CheckLists { get; set; }

        public int? FinishedItem
        {
            get
            {
                return CheckLists?.Count(list => list.IsFinished == true);
            }
        }

        public int? MaxNum
        {
            get
            {
                return CheckLists?.Count();
            }
        }
        public string NumStr
        {
            get
            {
                return $"{FinishedItem} / {MaxNum}";
            }
        }
    }
}
