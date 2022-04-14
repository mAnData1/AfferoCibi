using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public class CustomerListOfOrdersViewModel : BaseViewModel
    {
        private ObservableCollection<MealViewModel> meals;

        public ICollection<MealViewModel> Meals => meals;

        public CustomerListOfOrdersViewModel(ObservableCollection<MealViewModel> meals)
        {
            this.meals = new ObservableCollection<MealViewModel>();
        }
    }
}
