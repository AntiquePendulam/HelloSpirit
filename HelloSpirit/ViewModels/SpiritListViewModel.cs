using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace HelloSpirit
{
    public class SpiritListViewModel : BindableBase
    {
        private string _listTitle;
        public string ListTitle
        {
            get { return _listTitle; }
            set { this.SetProperty(ref _listTitle, value); }
        }

        private ObservableCollection<Spirit> _list;
        public ObservableCollection<Spirit> List
        {
            get { return this._list; }
            set { this.SetProperty(ref _list, value); }
        }
    }
}
