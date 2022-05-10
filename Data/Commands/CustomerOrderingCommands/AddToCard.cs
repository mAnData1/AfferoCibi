using Data.Entities;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Commands.CustomerOrderingCommands
{
    public class AddToCard : BaseCommand
    {
        private CustomerOrderingViewModel customerOrderingViewModel;
        private MealCardCustomerViewModel mealCardCustomerViewModel;

        public AddToCard(CustomerOrderingViewModel customerOrderingViewModel, MealCardCustomerViewModel mealCardCustomerViewModel)
        {
            this.customerOrderingViewModel = customerOrderingViewModel;
            this.mealCardCustomerViewModel = mealCardCustomerViewModel;
        }

        public override void Execute(object? parameter)
        {
            customerOrderingViewModel.OrderedMeals.Add(mealCardCustomerViewModel);
        }
    }
}
