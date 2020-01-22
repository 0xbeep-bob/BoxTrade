using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace BoxTrade.Helpers
{
    public class NotifyPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetPropertyValue<T>(ref T field, T value, [CallerMemberName]string propertyName = "", params string[] properties)
        {
            field = value;
            RaisePropertyChanged(propertyName);
            if (properties != null)
                foreach (var pr in properties)
                    RaisePropertyChanged(pr);
        }
    }
}
