using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Reactive.Bindings.Extensions;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Windows;
using System.Reactive.Linq;

namespace HelloSpirit
{
    public class Spirit : BindableBase
    {
        public Spirit(ObservableCollection<CheckList> checks)
        {
            CheckLists = checks;
            Initialize();
            CheckLists.ObserveElementProperty(x => x.IsFinished).Subscribe(x => FinishedItem = CheckLists.Count(list => list.IsFinished == true));
            CheckLists.CollectionChanged += (s, e) => { MaxNum = CheckLists.Count(); NumStrRefresh(); };
        }

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
        public ObservableCollection<CheckList> CheckLists { get; set; }

        public int? _finishedItem;
        public int? FinishedItem
        {
            get { return _finishedItem; }
            set { this.SetProperty(ref _finishedItem, value); NumStrRefresh(); }
        }

        public int? _maxnum;
        public int? MaxNum
        {
            get { return _maxnum; }
            set { this.SetProperty(ref _maxnum, value); NumStrRefresh(); }
        }

        private string _numstr;
        public string NumStr
        {
            get { return _numstr; }
            set { this.SetProperty(ref _numstr, value); }
        }
        private void NumStrRefresh()
        {
            NumStr = $"{FinishedItem}/{MaxNum}";
        }
        private void Initialize()
        {
            FinishedItem = CheckLists.Count(list => list.IsFinished == true);
            MaxNum = CheckLists.Count();
        }
    }
}
