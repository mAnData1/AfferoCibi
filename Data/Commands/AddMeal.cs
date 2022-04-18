using Data.Entities;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Commands
{
    public class AddMeal : BaseCommand
    {

        private AdminCorrectionsViewModel adminCorrectionsViewModel;

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(adminCorrectionsViewModel.Name) 
                && !string.IsNullOrEmpty(adminCorrectionsViewModel.Price.ToString())
                && !string.IsNullOrEmpty(adminCorrectionsViewModel.Ingredients)
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
            adminCorrectionsViewModel.Name = "";
            adminCorrectionsViewModel.Price = 0;
            adminCorrectionsViewModel.Ingredients = "";
            adminCorrectionsViewModel.SelectedMeal = null;
        }
        public override void Execute(object? parameter)
        {
            Meal meal = new Meal(adminCorrectionsViewModel.Name, adminCorrectionsViewModel.Price, adminCorrectionsViewModel.Ingredients);
            MealViewModel viewModel = new MealViewModel(meal);
            adminCorrectionsViewModel.Meals.Add(viewModel);
            ClearTextBoxes();
        }

        private void TextBoxesChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(adminCorrectionsViewModel.Name)
               || e.PropertyName == nameof(adminCorrectionsViewModel.Price)
               || e.PropertyName == nameof(adminCorrectionsViewModel.Ingredients))
            {
                OnExecutedChanged();
            }
        }
    }
}
