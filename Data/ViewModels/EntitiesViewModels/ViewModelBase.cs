using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {        
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChaneg(string? propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}
