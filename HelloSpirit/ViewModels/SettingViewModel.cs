using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagePack;

namespace HelloSpirit.ViewModels
{
    [MessagePackObject]
    public class SettingViewModel : BindableBase
    {
        [IgnoreMember]
        private string _userName;
        [Key(0)]
        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }
        [IgnoreMember]
        private string _gitHubName;
        [Key(1)]
        public string GitHubName
        {
            get { return _gitHubName; }
            set { SetProperty(ref _gitHubName, value); }
        }
    }
}
