using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Commands
{
    public class UpdateMeal : BaseCommand
    {
        private AdminCorrectionsViewModel adminCorrectionsViewModel;

        public override bool CanExecute(object? parameter)
        {
            if (adminCorrectionsViewModel.SelectedMeal == null)
            {
                return false && base.CanExecute(parameter);
            }
            else
            return true && base.CanExecute(parameter);
        }
        public override void Execute(object? parameter)
        {
            adminCorrectionsViewModel.Name = adminCorrectionsViewModel.SelectedMeal.Name;
            adminCorrectionsViewModel.Price = adminCorrectionsViewModel.SelectedMeal.Price;
            adminCorrectionsViewModel.Ingredients = adminCorrectionsViewModel.SelectedMeal.Ingredients;
            adminCorrectionsViewModel.AddMealCommand.Enabled = false;
            adminCorrectionsViewModel.SaveChangesCommand.Enabled = true;
            
        }
        public UpdateMeal(AdminCorrectionsViewModel adminCorrectionsViewModel)
        {
            this.adminCorrectionsViewModel = adminCorrectionsViewModel;
            adminCorrectionsViewModel.PropertyChanged += MealSelected;
            
        }

        private void MealSelected(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(adminCorrectionsViewModel.SelectedMeal))
            {
                OnExecutedChanged();
            }
        }
    }
}
