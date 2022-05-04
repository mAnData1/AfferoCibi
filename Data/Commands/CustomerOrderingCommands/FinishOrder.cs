using Data.Entities;
using Data.Services;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Commands.CustomerOrderingCommands
{
    public class FinishOrder : BaseCommand
    {
        private CustomerOrderingViewModel customerOrderingViewModel;
        private readonly NavigationService customerListOfOrdersNavigate;

        public FinishOrder(CustomerOrderingViewModel customerOrderingViewModel, NavigationService customerListOfOrdersNavigate)
        {
            this.customerOrderingViewModel = customerOrderingViewModel;
            this.customerListOfOrdersNavigate = customerListOfOrdersNavigate;
            customerOrderingViewModel.PropertyChanged += MealsAndAdressChanged;
        }

        private void MealsAndAdressChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(customerOrderingViewModel.Address) 
                || e.PropertyName == nameof(customerOrderingViewModel.OrderedMeals))
            {
                OnExecutedChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            if (customerOrderingViewModel.OrderedMeals != null && customerOrderingViewModel.OrderedMeals.Count != 0
                && customerOrderingViewModel.Address != "")
            {
                return true
                    && base.CanExecute(parameter);
            }
            return false;
        }

        public override void Execute(object? parameter)
        {
            OrderViewModel orderViewModel = new OrderViewModel(CreateOrder());
            customerListOfOrdersNavigate.Navigate();
        }

        private Order CreateOrder()
        {
            Order order = new Order(customerOrderingViewModel.Address, DateTime.Now);
            List<Meal> meals = new List<Meal>();

            foreach (var ViewModel in customerOrderingViewModel.Meals)
            {
                meals.Add(new Meal(ViewModel.MealImage, ViewModel.Name, ViewModel.Price, ViewModel.Ingredients));
            }
            order.Meals = meals;

            return order;
        }
    }
}
