using Data.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Data.ViewModels
{
    public  class CustomerOrderingViewModel : BaseViewModel
    {
        private string? address;

        public string? Address
        {
            get { return address; }
            set { address = value; OnPropertyChaneg(nameof(address)); }
        }

        private ObservableCollection<MealViewModel>? meals;

        public IEnumerable<MealViewModel>? Meals => meals;

        public CustomerOrderingViewModel()
        {
            meals = new ObservableCollection<MealViewModel>();
            orderedMeals = new ObservableCollection<MealViewModel>();
        }

        private ObservableCollection<MealViewModel>? orderedMeals;

        public IEnumerable<MealViewModel>? OrderedMeals => orderedMeals;

        public ICommand? AddCommand { get; }

        public ICommand? RemoveCommand { get; }

        public ICommand? FinishCommand { get; }
    }
}
