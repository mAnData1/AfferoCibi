using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Commands.AdminCorrectionsViewModelCommands
{
    public class DeleteMeal : BaseCommand
    {
        private AdminCorrectionsViewModel adminCorrectionsViewModel;
        private MealCardAdminViewModel mealCardAdminViewModel;
        public override void Execute(object? parameter)
        {
            adminCorrectionsViewModel.Meals.Remove(mealCardAdminViewModel);
        }

        public DeleteMeal(AdminCorrectionsViewModel adminCorrectionsViewModel, MealCardAdminViewModel mealCardAdminViewModel)
        {
            this.adminCorrectionsViewModel = adminCorrectionsViewModel;
            this.mealCardAdminViewModel = mealCardAdminViewModel;
        }

    }
}
