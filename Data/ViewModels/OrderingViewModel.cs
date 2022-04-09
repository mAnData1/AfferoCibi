using Data.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public class OrderingViewModel
    {
        private ObservableCollection<Meal> meals;

        public ObservableCollection<Meal> Meals
        {
            get { return meals; }
            set { meals = value; }
        }

    }
}
