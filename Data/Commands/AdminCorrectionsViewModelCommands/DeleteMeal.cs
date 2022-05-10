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
    public class DeleteMeal : BaseAsyncCommand
    {
        private AdminCorrectionsViewModel adminCorrectionsViewModel;
        private MealCardAdminViewModel mealCardAdminViewModel;

        public DeleteMeal(AdminCorrectionsViewModel adminCorrectionsViewModel, MealCardAdminViewModel mealCardAdminViewModel)
        {
            this.adminCorrectionsViewModel = adminCorrectionsViewModel;
            this.mealCardAdminViewModel = mealCardAdminViewModel;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            Meal meal = mealCardAdminViewModel.ViewModelToModel(mealCardAdminViewModel);
            Guid id = await adminCorrectionsViewModel.mealService.GetID(meal);
            await adminCorrectionsViewModel.mealService.Delete(id);

            adminCorrectionsViewModel.RefreshMealsList();
        }

    }
}
