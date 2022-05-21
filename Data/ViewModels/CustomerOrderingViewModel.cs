using Data.Commands;
using Data.Commands.CustomerOrderingCommands;
using Data.Entities;
using Data.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Data.ViewModels
{
    public  class CustomerOrderingViewModel : BaseHelpViewModel
    {
        private string? address;

        public string? Address
        {
            get { return address; }
            set { address = value; OnPropertyChaneg(nameof(Address)); }
        }
        private int selectedOrderedMeal = -1;

        public int SelectedOrderedMeal
        {
            get { return selectedOrderedMeal; }
            set { selectedOrderedMeal = value; OnPropertyChaneg(nameof(SelectedOrderedMeal)); }
        }

        private ObservableCollection<MealViewModel>? meals;

        public ObservableCollection<MealViewModel>? Meals
        {
            get { return meals; }
            set { meals = value; }
        }
        private ObservableCollection<MealViewModel>? orderedMeals;

        public ObservableCollection<MealViewModel>? OrderedMeals
        {
            get { return orderedMeals; }
            set { orderedMeals = value; }
        }

        public RemoveMeal RemoveCommand { get; }
        public ICommand? FinishCommand { get; }
        public NavigateCommand NavigateToCustomerListOfOtders { get; }

        public CustomerOrderingViewModel(NavigationService customerListOfOrders, NavigationService helpNavigationService)
            : base(helpNavigationService)
        {
            RemoveCommand = new RemoveMeal(this);
            NavigateToCustomerListOfOtders = new NavigateCommand(customerListOfOrders);
            meals = new ObservableCollection<MealViewModel>();
            meals.Add(new MealViewModel(new Meal(null, "test", 12.34m, "tomates")));
            meals.Add(new MealViewModel(new Meal(null, "test", 12.34m, "tomates")));
            meals.Add(new MealViewModel(new Meal(null, "test", 12.34m, "tomates")));
            meals.Add(new MealViewModel(new Meal(null, "test", 12.34m, "tomates")));
            orderedMeals = new ObservableCollection<MealViewModel>();
        }
    }
}
