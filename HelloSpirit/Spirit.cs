using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloSpirit
{
    public class Spirit : BindableBase
    {
        private string _title;
        public string Title
        {
            get { return this._title; }
            set { this.SetProperty(ref this._title, value); }
        }
        private string _description;
        public string Description
        {
            get { return this._description; }
            set { this.SetProperty(ref this._description, value); }
        }
        private DateTime? _limitdate;
        public DateTime? LimitDate
        {
            get { return this._limitdate; }
            set { this.SetProperty(ref this._limitdate, value); }
        }
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
