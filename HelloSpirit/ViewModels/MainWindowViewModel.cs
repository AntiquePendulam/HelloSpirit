using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using MessagePack;

namespace HelloSpirit
{
    [MessagePackObject]
    public class MainWindowViewModel : BindableBase
    {
        [IgnoreMember]
        public string UserName
        {
            get { return $"Hello!{App.UserName}"; }
        }

        [IgnoreMember]
        private ObservableCollection<SpiritListViewModel> _lists;

        [Key(0)]
        public ObservableCollection<SpiritListViewModel> Lists
        {
            get { return _lists; }
            set { SetProperty(ref _lists, value); }
        }
    }
}
