using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HelloSpirit
{
    public class BindableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual bool SetProperty<T>(ref T field, T value, [CallerMemberName]string propertyname = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
            return true;
        }
    }
}
