using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using MessagePack;

namespace HelloSpirit.ViewModels
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
        private ObservableCollection<SpiritViewModel> _list;

        [Key(1)]
        public ObservableCollection<SpiritViewModel> List
        {
            get
            {
                if (_list == null) _list = new ObservableCollection<SpiritViewModel>();
                return _list;
            }
            set { this.SetProperty(ref _list, value); }
        }
    }
}
