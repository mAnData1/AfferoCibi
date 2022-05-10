using Data.Entities;
using Data.Services;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Commands.AdminCorrectionsViewModelCommands
{
    public class AddMeal : BaseAsyncCommand
    {

        private AdminCorrectionsViewModel adminCorrectionsViewModel;

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(adminCorrectionsViewModel.InputName) 
                && !string.IsNullOrEmpty(adminCorrectionsViewModel.InputPrice.ToString())
                && !string.IsNullOrEmpty(adminCorrectionsViewModel.InputIngredients)
                && Enabled
                && base.CanExecute(parameter);
        }

        public AddMeal(AdminCorrectionsViewModel adminCorrectionsViewModel)
        {
            this.adminCorrectionsViewModel = adminCorrectionsViewModel;
            adminCorrectionsViewModel.PropertyChanged += TextBoxesChanged;
            
        }
        private void ClearTextBoxes()
        {
            adminCorrectionsViewModel.InputName = "";
            adminCorrectionsViewModel.InputPrice = 0;
            adminCorrectionsViewModel.InputIngredients = "";
        }
        public override async Task ExecuteAsync(object? parameter)
        {
            Meal meal = new Meal(adminCorrectionsViewModel.InputImage, adminCorrectionsViewModel.InputName,
                adminCorrectionsViewModel.InputPrice, adminCorrectionsViewModel.InputIngredients);

            await adminCorrectionsViewModel.mealService.Create(meal);

            ClearTextBoxes();
            adminCorrectionsViewModel.RefreshMealsList();
        }

        private void TextBoxesChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(adminCorrectionsViewModel.InputName)
               || e.PropertyName == nameof(adminCorrectionsViewModel.InputPrice)
               || e.PropertyName == nameof(adminCorrectionsViewModel.InputIngredients))
            {
                OnExecutedChanged();
            }
        }
    }
}
