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
    public class SaveChanges : BaseCommand
    {
        private AdminCorrectionsViewModel adminCorrectionsViewModel;
        private int index = 0;
        private MealViewModel updatedMeal;
        private Meal meal;
        public SaveChanges(AdminCorrectionsViewModel adminCorrectionsViewModel)
        {
            Enabled = false;
            this.adminCorrectionsViewModel = adminCorrectionsViewModel;
            adminCorrectionsViewModel.PropertyChanged += TextBoxesChanged;
            index = adminCorrectionsViewModel.IndexOfSelectedMeal;
            adminCorrectionsViewModel.AddMealCommand.Enabled = true;
        }
        public override bool CanExecute(object? parameter)
        {
            return 
                Enabled
                && base.CanExecute(parameter);
        }
        public override void Execute(object? parameter)
        {
            string Name = adminCorrectionsViewModel.Name;
            decimal Price = adminCorrectionsViewModel.Price;
            string Ingredients = adminCorrectionsViewModel.Ingredients;

            adminCorrectionsViewModel.SelectedMeal.Name = adminCorrectionsViewModel.Name;

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
        private void ClearTextBoxes()
        {
            adminCorrectionsViewModel.Name = "";
            adminCorrectionsViewModel.Price = 0;
            adminCorrectionsViewModel.Ingredients = "";
            adminCorrectionsViewModel.SelectedMeal = null;
        }
    }
}
