using Data.Commands;
using Data.Commands.CustomerOrderingCommands;
using Data.Entities;
using Data.Services;
using Data.Services.Interfaces;
using DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Data.ViewModels
{
    public class CustomerOrderingViewModel : BaseViewModelWithMealServices
    {
        private IOrderService orderService;
        private string? address;
        public string? Address
        {
            get { return address; }
            set { address = value; OnPropertyChanged(nameof(Address)); }
        }

        private int selectedOrderedMeal = -1;
        public int SelectedOrderedMeal
        {
            get { return selectedOrderedMeal; }
            set { selectedOrderedMeal = value; OnPropertyChanged(nameof(SelectedOrderedMeal)); }
        }

        private ObservableCollection<MealCardCustomerViewModel> meals;
        public ObservableCollection<MealCardCustomerViewModel> Meals
        {
            get { return meals; }
            set { meals = value; }
        }

        private ObservableCollection<MealCardCustomerViewModel> orderedMeals;
        public ObservableCollection<MealCardCustomerViewModel> OrderedMeals
        {
            get { return orderedMeals; }
            set { orderedMeals = value; OnPropertyChanged(nameof(OrderedMeals)); }
        }

        public BaseCommand RemoveCommand { get; }
        public BaseCommand FinishOrderCommand { get; }
        public NavigateCommand NavigateToCustomerListOfOtders { get; }
        public BaseCommand LoadMealsCommand { get; }

        public CustomerOrderingViewModel(NavigationService customerListOfOrdersNavigationService, NavigationService helpNavigationService, IMealService mealService, IOrderService orderService)
            : base(helpNavigationService, mealService)
        {
            Meals = new ObservableCollection<MealCardCustomerViewModel>();
            OrderedMeals = new ObservableCollection<MealCardCustomerViewModel>();
            OrderedMeals.CollectionChanged += OnCollectionChanged;
            RemoveCommand = new RemoveMeal(this);
            FinishOrderCommand = new FinishOrder(this, customerListOfOrdersNavigationService, orderService);
            NavigateToCustomerListOfOtders = new NavigateCommand(customerListOfOrdersNavigationService);

            LoadMealsCommand = new LoadMeals<CustomerOrderingViewModel>(this);
            this.orderService = orderService;
        }

        private void OnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(OrderedMeals));
        }

        public static CustomerOrderingViewModel LoadViewModel(NavigationService customerListOfOrders, NavigationService helpNavigationService, IMealService mealService, IOrderService orderService)
        {
            CustomerOrderingViewModel viewModel = new CustomerOrderingViewModel(customerListOfOrders, helpNavigationService, mealService, orderService);
            viewModel.LoadMealsCommand.Execute(null);

            return viewModel;
        }

        public override void LoadMealsList(ICollection<Meal> meals)
        {
            Meals.Clear();
            foreach (var meal in meals)
            {
                Meals.Add(new MealCardCustomerViewModel(meal, this));
            }
        }
    }
}
