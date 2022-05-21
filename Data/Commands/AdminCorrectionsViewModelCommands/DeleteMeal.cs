using Data.Entities;
using Data.Stores;
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
        private readonly AdminCorrectionsViewModel adminCorrectionsViewModel;
        private readonly MealCardAdminViewModel mealCardAdminViewModel;
        private readonly MealsStore mealsStore;
        public DeleteMeal(AdminCorrectionsViewModel adminCorrectionsViewModel, MealCardAdminViewModel mealCardAdminViewModel, MealsStore mealsStore)
        {
            this.adminCorrectionsViewModel = adminCorrectionsViewModel;
            this.mealCardAdminViewModel = mealCardAdminViewModel;

            this.mealsStore = mealsStore;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            Meal meal = mealCardAdminViewModel.ViewModelToModel(mealCardAdminViewModel);
            await mealsStore.RemoveMeal(meal);

            adminCorrectionsViewModel.RefreshMealsList();
        }

    }
}
