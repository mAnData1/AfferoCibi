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

        private ObservableCollection<MealCardCustomerViewModel>? meals;

        public ObservableCollection<MealCardCustomerViewModel>? Meals
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

        public BaseCommand RemoveCommand { get; }
        public BaseCommand FinishOrderCommand { get; }
        public NavigateCommand NavigateToCustomerListOfOtders { get; }

        public CustomerOrderingViewModel(NavigationService customerListOfOrders, NavigationService helpNavigationService)
            : base(helpNavigationService)
        {
            RemoveCommand = new RemoveMeal(this);
            FinishOrderCommand = new FinishOrder(this, customerListOfOrders);
            NavigateToCustomerListOfOtders = new NavigateCommand(customerListOfOrders);
            meals = new ObservableCollection<MealCardCustomerViewModel>();
            meals.Add(new MealCardCustomerViewModel(new Meal(null, "test", 12.34m, "tomates"), this));
            meals.Add(new MealCardCustomerViewModel(new Meal(null, "test", 12.34m, "tomates"), this));
            meals.Add(new MealCardCustomerViewModel(new Meal(null, "test", 12.34m, "tomates"), this));
            meals.Add(new MealCardCustomerViewModel(new Meal(null, "test", 12.34m, "tomates"), this));
            orderedMeals = new ObservableCollection<MealViewModel>();
        }
    }
}
