using Data.Commands;
using Data.Services;
using DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {        
        public event PropertyChangedEventHandler? PropertyChanged;        
        protected void OnPropertyChanged(string? propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}
