using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Commands.AdminCorrectionsViewModelCommands
{
    public class UpdateMeal : BaseCommand
    {
        private AdminCorrectionsViewModel adminCorrectionsViewModel;
        private MealCardAdminViewModel mealCardAdminViewModel;

        public override void Execute(object? parameter)
        {
            adminCorrectionsViewModel.AddMealCommand.Enabled = false;
            adminCorrectionsViewModel.SaveChangesCommand.Enabled = true;

            adminCorrectionsViewModel.InputName = mealCardAdminViewModel.Name;
            adminCorrectionsViewModel.InputPrice = mealCardAdminViewModel.Price;
            adminCorrectionsViewModel.InputIngredients = mealCardAdminViewModel.Ingredients;

            adminCorrectionsViewModel.SelectedMeal = mealCardAdminViewModel;
        }
        public UpdateMeal(AdminCorrectionsViewModel adminCorrectionsViewModel, MealCardAdminViewModel mealCardAdminViewModel)
        {
            this.adminCorrectionsViewModel = adminCorrectionsViewModel;
            this.mealCardAdminViewModel = mealCardAdminViewModel;
        }
    }
}
