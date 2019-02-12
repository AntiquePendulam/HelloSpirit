using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloSpirit
{
    public class CheckList : BindableBase
    {
        private string _title;
        public string Title
        {
            get { return this._title; }
            set { this.SetProperty(ref this._title, value); }
        }
        private bool _isfinished;
        public bool IsFinished
        {
            get { return this._isfinished; }
            set { this.SetProperty(ref this._isfinished, value); }
        }
    }
}
