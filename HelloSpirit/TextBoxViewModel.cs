using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;

namespace HelloSpirit
{
    public class TextBoxViewModel :  INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private static readonly PropertyChangedEventArgs TextPropertyChangedEventArgs = new PropertyChangedEventArgs(nameof(Text));

        private string _text;
        public string Text
        {
            get { return this._text; }
            set
            {
                if (this._text == value) return;
                this._text = value;
                this.PropertyChanged?.Invoke(this, TextPropertyChangedEventArgs);
            }
        }
    }
}
