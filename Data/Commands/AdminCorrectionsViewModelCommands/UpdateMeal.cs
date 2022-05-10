using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Commands.AdminCorrectionsViewModelCommands
{
    public class UpdateMeal : BaseAsyncCommand
    {
        private AdminCorrectionsViewModel adminCorrectionsViewModel;
        private MealCardAdminViewModel mealCardAdminViewModel;

        public override async Task ExecuteAsync(object? parameter)
        {
            adminCorrectionsViewModel.AddMealCommand.Enabled = false;
            adminCorrectionsViewModel.SaveChangesCommand.Enabled = true;

            adminCorrectionsViewModel.InputName = mealCardAdminViewModel.Name;
            adminCorrectionsViewModel.InputPrice = mealCardAdminViewModel.Price;
            adminCorrectionsViewModel.InputIngredients = mealCardAdminViewModel.Ingredients;


            adminCorrectionsViewModel.UpdatedMeal = mealCardAdminViewModel;
            adminCorrectionsViewModel.UpdatedMealID = await adminCorrectionsViewModel.mealService.GetID(mealCardAdminViewModel.ViewModelToModel(mealCardAdminViewModel));
        }
        public UpdateMeal(AdminCorrectionsViewModel adminCorrectionsViewModel, MealCardAdminViewModel mealCardAdminViewModel)
        {
            this.adminCorrectionsViewModel = adminCorrectionsViewModel;
            this.mealCardAdminViewModel = mealCardAdminViewModel;
        }
    }
}
