using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Commands
{
    public class DeleteMeal : BaseCommand
    {
        private AdminCorrectionsViewModel adminCorrectionsViewModel;

        public override void Execute(object? parameter)
        {
            adminCorrectionsViewModel.Meals.Remove(adminCorrectionsViewModel.SelectedMeal);
        }

        public override bool CanExecute(object? parameter)
        {
            if (adminCorrectionsViewModel.SelectedMeal == null)
            {
                return false && Enabled && base.CanExecute(parameter);
            }
            else
                return true && Enabled && base.CanExecute(parameter);
        }

        public DeleteMeal(AdminCorrectionsViewModel adminCorrectionsViewModel)
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
