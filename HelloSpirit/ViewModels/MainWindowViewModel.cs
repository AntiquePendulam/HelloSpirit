﻿using MessagePack;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HelloSpirit.ViewModels
{
    [MessagePackObject]
    public class MainWindowViewModel : BindableBase
    {
        [IgnoreMember]
        private ObservableCollection<SpiritListViewModel> _lists;

        [Key(0)]
        public ObservableCollection<SpiritListViewModel> Lists
        {
            get
            {
                if (_lists == null) _lists = new ObservableCollection<SpiritListViewModel>();
                return _lists;
            }
            set { SetProperty(ref _lists, value); }
        }

        [IgnoreMember]
        private SettingViewModel _setting;

        [Key(1)]
        public SettingViewModel Setting
        {
            get
            {
                if (_setting == null) _setting = new SettingViewModel() { UserName = "AntiqueR", GitHubName = "AntiquePendulam" };
                return _setting;
            }
            set
            {
                SetProperty(ref _setting, value);
            }
        }

        public void UpdateViewModel(MainWindowViewModel model)
        {
            UpdateLists(model.Lists);
            this.Setting = model.Setting;
        }

        public void UpdateLists(ICollection<SpiritListViewModel> spirits)
        {
            Lists.Clear();
            foreach (var sp in spirits) Lists.Add(sp);
        }
    }
}
