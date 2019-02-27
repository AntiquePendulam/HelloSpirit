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
using MessagePack;

namespace HelloSpirit
{
    [MessagePackObject]
    public class Spirit : BindableBase
    {

        private string _title;

        [Key(0)]
        public string Title
        {
            get { return this._title; }
            set { this.SetProperty(ref this._title, value); }
        }

        private string _description;

        [Key(1)]
        public string Description
        {
            get { return this._description; }
            set { this.SetProperty(ref this._description, value); }
        }

        private DateTime? _limitdate = null;

        [Key(2)]
        public DateTime? LimitDate
        {
            get
            {
                if (_limitdate == null) _limitdate = new DateTime();
                return _limitdate;
            }
            set { this.SetProperty(ref this._limitdate, value); }
        }

        private ObservableCollection<CheckList> _checkList;
        [Key(3)]
        public ObservableCollection<CheckList> CheckLists
        {
            get { return _checkList; }
            set
            {
                if (value == null) return;
                this.SetProperty(ref _checkList, value);
                CheckLists.ObserveElementProperty(x => x.IsFinished).Subscribe(x => FinishedItem = CheckLists.Count(list => list.IsFinished == true));
                CheckLists.CollectionChanged += (s, e) => { MaxNum = CheckLists.Count(); NumStrRefresh(); };
            }
        }

        [IgnoreMember]
        private int? _finishedItem = null;
        [IgnoreMember]
        public int? FinishedItem
        {
            get
            {
                if(_finishedItem == null) _finishedItem = CheckLists?.Count(list => list.IsFinished == true);
                return _finishedItem;
            }
            set { this.SetProperty(ref _finishedItem, value); NumStrRefresh(); }
        }
        [IgnoreMember]
        private int? _maxnum = null;
        [IgnoreMember]
        public int? MaxNum
        {
            get
            {
                if (_maxnum == null) _maxnum = CheckLists?.Count();
                return _maxnum;
            }
            set { this.SetProperty(ref _maxnum, value); NumStrRefresh(); }
        }

        [IgnoreMember]
        private string _numstr;
        [IgnoreMember]
        public string NumStr
        {
            get
            {
                if (_numstr == null) NumStrRefresh();
                return _numstr;
            }
            set { this.SetProperty(ref _numstr, value); }
        }

        #region Methods
        private void NumStrRefresh()
        {
            NumStr = $"{FinishedItem}/{MaxNum}";
            if (NumStr == "/") NumStr = "";
        }
        #endregion
    }
}
