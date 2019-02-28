using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagePack;

namespace HelloSpirit.ViewModels
{
    [MessagePackObject]
    public class CheckListViewModel : BindableBase
    {
        public CheckListViewModel()
        {
            this.Title = "";
            this.IsFinished = false;
        }

        public CheckListViewModel(string title, bool isFinished)
        {
            this.Title = title;
            this.IsFinished = isFinished;
        }

        private string _title;
        [Key(0)]
        public string Title
        {
            get { return this._title; }
            set { this.SetProperty(ref this._title, value); }
        }

        private bool _isfinished;

        [Key(1)]
        public bool IsFinished
        {
            get { return this._isfinished; }
            set { this.SetProperty(ref this._isfinished, value); }
        }
    }
}
