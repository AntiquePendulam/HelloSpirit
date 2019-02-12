using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace HelloSpirit
{
    public class MainWindowViewModel : BindableBase
    {
        public string UserName
        {
            get { return $"Hello!{App.UserName}"; }
        }

        private ObservableCollection<SpiritListViewModel> _lists;
        public ObservableCollection<SpiritListViewModel> Lists
        {
            get { return _lists; }
            set { SetProperty(ref _lists, value); }
        }
    }
}
