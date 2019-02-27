using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using MessagePack;

namespace HelloSpirit
{
    [MessagePackObject]
    public class SpiritListViewModel : BindableBase
    {
        [IgnoreMember]
        private string _listTitle;

        [Key(0)]
        public string ListTitle
        {
            get { return _listTitle; }
            set { this.SetProperty(ref _listTitle, value); }
        }

        [IgnoreMember]
        private ObservableCollection<Spirit> _list;

        [Key(1)]
        public ObservableCollection<Spirit> List
        {
            get
            {
                if (_list == null) _list = new ObservableCollection<Spirit>();
                return _list;
            }
            set { this.SetProperty(ref _list, value); }
        }
    }
}
