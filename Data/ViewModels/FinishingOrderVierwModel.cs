using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace Data.ViewModels
{
    public class FinishingOrderVierwModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); 
        }


        private string warrantor;

        public string Warrantor
        {
            get { return warrantor; }
            set { warrantor = value;
                NotifyPropertyChanged();  }
        }

        private ObservableCollection<Meals> meals;

        public ObservableCollection<Meals> Meals
        {
            get { return meals; }
            set { meals = value; }
        }


    }
}
