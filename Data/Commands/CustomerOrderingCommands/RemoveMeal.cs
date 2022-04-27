using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Commands.CustomerOrderingCommands
{
    public class RemoveMeal : BaseCommand
    {
        private CustomerOrderingViewModel customerOrderingViewModel;
        public override bool CanExecute(object? parameter)
        {
            if (customerOrderingViewModel.SelectedOrderedMeal == -1 )
                return false && base.CanExecute(parameter);
            else
                return true && base.CanExecute(parameter);
        }
        public override void Execute(object? parameter)
        {
            customerOrderingViewModel.OrderedMeals.RemoveAt(customerOrderingViewModel.SelectedOrderedMeal);
        }
        public RemoveMeal(CustomerOrderingViewModel customerOrderingViewModel)
        {
            this.customerOrderingViewModel = customerOrderingViewModel;
            customerOrderingViewModel.PropertyChanged += SelectedMealChanged;
        }

        private void SelectedMealChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(customerOrderingViewModel.SelectedOrderedMeal))
            {
                OnExecutedChanged();
            }
        }
    }
}
