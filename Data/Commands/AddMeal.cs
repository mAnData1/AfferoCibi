using Data.Entities;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Commands
{
    public class AddMeal : BaseCommand
    {
        private AdminCorrectionsViewModel adminCorrectionsViewModel;

        public AddMeal(AdminCorrectionsViewModel adminCorrectionsViewModel)
        {
            this.adminCorrectionsViewModel = adminCorrectionsViewModel;
        }
        private void ClearTextBoxes()
        {
            adminCorrectionsViewModel.Name = "";
            adminCorrectionsViewModel.Price = 0;
            adminCorrectionsViewModel.Ingredients = "";
        }
        public override void Execute(object? parameter)
        {
            Meal meal = new Meal(adminCorrectionsViewModel.Name, adminCorrectionsViewModel.Price, adminCorrectionsViewModel.Ingredients);
            MealViewModel viewModel = new MealViewModel(meal);
            adminCorrectionsViewModel.Meals.Add(viewModel);
            ClearTextBoxes();
        }
        
    }
}
