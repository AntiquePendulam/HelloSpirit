using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using GongSolutions.Wpf.DragDrop;
using GongSolutions.Wpf.DragDrop.Utilities;

namespace HelloSpirit
{
    public class SpiritListVM : BindableBase
    {

        public ObservableCollection<Spirit> _items;
        public ObservableCollection<Spirit> Items
        {
            get { return this._items; }
            set
            {
                _items = value;
                this.SetProperty(ref _items, value);
            }
        }
        public ObservableCollection<Spirit> _items2;
        public ObservableCollection<Spirit> Items2
        {
            get { return this._items2; }
            set
            {
                _items2 = value;
                this.SetProperty(ref _items2, value);
            }
        }
        public ObservableCollection<Spirit> _items3;
        public ObservableCollection<Spirit> Items3
        {
            get { return this._items3; }
            set
            {
                _items3 = value;
                this.SetProperty(ref _items3, value);
            }
        }
    }
}
