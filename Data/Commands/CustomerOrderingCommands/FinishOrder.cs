using Data.Entities;
using Data.Services;
using Data.Services.Interfaces;
using Data.Stores;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Commands.CustomerOrderingCommands
{
    public class FinishOrder : BaseAsyncCommand
    {
        private CustomerOrderingViewModel customerOrderingViewModel;
        private readonly NavigationService<CustomerListOfOrdersViewModel, CustomerOrderingViewModel> customerListOfOrdersNavigate;
        private readonly OrdersStore ordersStore;
        public FinishOrder(CustomerOrderingViewModel customerOrderingViewModel, 
            NavigationService<CustomerListOfOrdersViewModel, CustomerOrderingViewModel> customerListOfOrdersNavigate, 
            OrdersStore ordersStore)
        {
            this.customerOrderingViewModel = customerOrderingViewModel;
            this.customerListOfOrdersNavigate = customerListOfOrdersNavigate;
            customerOrderingViewModel.PropertyChanged += AdressChanged;
            customerOrderingViewModel.OrderedMeals.CollectionChanged += MealsChanged;
            this.ordersStore = ordersStore;
        }

        private void MealsChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            OnExecutedChanged();
        }

        private void AdressChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(customerOrderingViewModel.Address))
            {
                OnExecutedChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            if (customerOrderingViewModel.OrderedMeals != null 
                && customerOrderingViewModel.OrderedMeals.Count != 0
                && customerOrderingViewModel.Address != ""
                && customerOrderingViewModel.Address != null)
            {
                return true
                    && base.CanExecute(parameter);
            }
            return false;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            await ordersStore.AddOrder(CreateOrder());   
            customerListOfOrdersNavigate.Navigate();
        }

        private Order CreateOrder()
        {
            Order order = new Order(customerOrderingViewModel.Address, DateTime.Now);
            List<Meal> meals = new List<Meal>();

            foreach (var ViewModel in customerOrderingViewModel.OrderedMeals)
            {
                meals.Add(new Meal(ViewModel.MealImage, ViewModel.Name, ViewModel.Price, ViewModel.Ingredients));
            }
            order.Meals = meals;

            return order;
        }
    }
}
