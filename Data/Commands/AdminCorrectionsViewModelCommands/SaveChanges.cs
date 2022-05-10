using Data.Entities;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Commands.AdminCorrectionsViewModelCommands
{
    public class SaveChanges : BaseAsyncCommand
    {
        private AdminCorrectionsViewModel adminCorrectionsViewModel;
        private Guid id;
        private MealCardAdminViewModel updatedMeal;
        public SaveChanges(AdminCorrectionsViewModel adminCorrectionsViewModel)
        {
            Enabled = false;
            this.adminCorrectionsViewModel = adminCorrectionsViewModel;
            adminCorrectionsViewModel.PropertyChanged += UpdatedMealChanged;
            adminCorrectionsViewModel.AddMealCommand.Enabled = true;
            id = adminCorrectionsViewModel.UpdatedMealID;           
        }
        public override bool CanExecute(object? parameter)
        {
            return 
                Enabled
                && base.CanExecute(parameter);
        }
        public override async Task ExecuteAsync(object? parameter)
        {
            
            updatedMeal.Name = adminCorrectionsViewModel.InputName;
            updatedMeal.Price = adminCorrectionsViewModel.InputPrice;
            updatedMeal.Ingredients = adminCorrectionsViewModel.InputIngredients;

            Meal meal = updatedMeal.ViewModelToModel(updatedMeal);

            await adminCorrectionsViewModel.mealService.UpdateNameIncuded(id, meal);

            adminCorrectionsViewModel.RefreshMealsList();
            ClearTextBoxes();

            Enabled = false;
            adminCorrectionsViewModel.AddMealCommand.Enabled = true;
            
        }
        private void UpdatedMealChanged(object? sender, PropertyChangedEventArgs e)
        {
           if (e.PropertyName == nameof(adminCorrectionsViewModel.UpdatedMeal)
                || e.PropertyName == nameof(adminCorrectionsViewModel.UpdatedMealID))
           {
                OnUpdatedMealChanged();
           }
        }
        private void ClearTextBoxes()
        {
            adminCorrectionsViewModel.InputName = "";
            adminCorrectionsViewModel.InputPrice = 0;
            adminCorrectionsViewModel.InputIngredients = "";
        }

        private void OnUpdatedMealChanged()
        {
            id = adminCorrectionsViewModel.UpdatedMealID;
            updatedMeal = adminCorrectionsViewModel.UpdatedMeal;
        }
    }
}
