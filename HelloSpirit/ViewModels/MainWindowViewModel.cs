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
        private ObservableCollection<SpiritListViewModel> _lists;

        [Key(0)]
        public ObservableCollection<SpiritListViewModel> Lists
        {
            get { return _lists; }
            set { SetProperty(ref _lists, value); }
        }

        [Key(1)]
        public string UserName { get; set; }

        [Key(2)]
        public string GitHubName { get; set; }
    }
}
