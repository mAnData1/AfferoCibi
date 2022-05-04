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
    public class SaveChanges : BaseCommand
    {
        private AdminCorrectionsViewModel adminCorrectionsViewModel;
        private MealCardAdminViewModel mealCardAdminViewModel;
        public SaveChanges(AdminCorrectionsViewModel adminCorrectionsViewModel)
        {
            Enabled = false;
            this.adminCorrectionsViewModel = adminCorrectionsViewModel;
            adminCorrectionsViewModel.PropertyChanged += UpdatedMealChanged;
            adminCorrectionsViewModel.AddMealCommand.Enabled = true;
            this.mealCardAdminViewModel = adminCorrectionsViewModel.SelectedMeal;           
        }
        public override bool CanExecute(object? parameter)
        {
            return 
                Enabled
                && base.CanExecute(parameter);
        }
        public override void Execute(object? parameter)
        {
            MealCardAdminViewModel updatedMeal = adminCorrectionsViewModel.Meals.First(m => m == mealCardAdminViewModel);
            int index = adminCorrectionsViewModel.Meals.IndexOf(mealCardAdminViewModel);
            updatedMeal.Name = adminCorrectionsViewModel.InputName;
            updatedMeal.Price = adminCorrectionsViewModel.InputPrice;
            updatedMeal.Ingredients = adminCorrectionsViewModel.InputIngredients;

            adminCorrectionsViewModel.Meals.Insert(index, updatedMeal);
            adminCorrectionsViewModel.Meals.RemoveAt(index+1);
            Enabled = false;
            adminCorrectionsViewModel.AddMealCommand.Enabled = true;
            ClearTextBoxes();
        }
        private void UpdatedMealChanged(object? sender, PropertyChangedEventArgs e)
        {
           if (e.PropertyName == nameof(adminCorrectionsViewModel.SelectedMeal))
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
            mealCardAdminViewModel = adminCorrectionsViewModel.SelectedMeal;
        }
    }
}
