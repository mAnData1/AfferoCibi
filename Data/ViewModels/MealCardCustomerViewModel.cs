using Data.Commands;
using Data.Commands.CustomerOrderingCommands;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public class MealCardCustomerViewModel : MealViewModel
    {
        public MealCardCustomerViewModel(Meal meal, CustomerOrderingViewModel customerOrderingViewModel) 
            : base(meal)
        {
            AddToCardCommand = new AddToCard(customerOrderingViewModel,this);
        }
        public BaseCommand AddToCardCommand { get; }
    }
}
