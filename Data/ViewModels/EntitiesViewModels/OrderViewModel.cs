using Data.Entities;
using Data.Entities.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public class OrderViewModel : BaseViewModel
    {
        private Order order;

        public DateTime DateOfLastModified
        { 
            get {return order.DateOfLastModified;}
            set { order.DateOfLastModified = value;}
        }
        public virtual List<MealViewModel> Meals
        {
            get { return ToMealViewModels(order.Meals); }
            set { order.Meals = ToMeals(value); }
        }
        public OrderStatus OrderStatus
        {
            get {return order.OrderStatus;}
            set { order.OrderStatus = value;}
        }
        public string Address 
        { 
            get { return order.Address;} 
            set { order.Address = value;} 
        }
        public OrderViewModel(Order order)
        {
                this.order = order;
        }
        public Order ViewModelToModel(OrderViewModel viewModel)
        {
            Order order = new Order(viewModel.Address, viewModel.DateOfLastModified);
            order.OrderStatus = viewModel.OrderStatus;
            order.Meals = ToMeals(viewModel.Meals);

            return order;
        }
        private List<MealViewModel> ToMealViewModels(List<Meal> meals)
        {
            List<MealViewModel> result = new List<MealViewModel>();
            foreach (Meal meal in meals)
            {
                result.Add(new MealViewModel(meal));
            }

            return result;
        }
        private List<Meal> ToMeals(List<MealViewModel> viewModels)
        {
            List<Meal> result = new List<Meal>();
            foreach (var viewModel in viewModels)
            {
                result.Add(viewModel.ViewModelToModel(viewModel));
            }
            return result;
        }
    }
}
