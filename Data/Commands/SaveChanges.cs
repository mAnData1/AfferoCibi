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
            string Name = adminCorrectionsViewModel.InputName;
            decimal Price = adminCorrectionsViewModel.InputPrice;
            string Ingredients = adminCorrectionsViewModel.InputIngredients;

            

            ClearTextBoxes();
        }
        private void TextBoxesChanged(object? sender, PropertyChangedEventArgs e)
        {
           if (e.PropertyName == nameof(adminCorrectionsViewModel.InputName)
               || e.PropertyName == nameof(adminCorrectionsViewModel.InputPrice)
               || e.PropertyName == nameof(adminCorrectionsViewModel.InputIngredients))
            {
                OnExecutedChanged();
            }
        }
        private void ClearTextBoxes()
        {
            adminCorrectionsViewModel.InputName = "";
            adminCorrectionsViewModel.InputPrice = 0;
            adminCorrectionsViewModel.InputIngredients = "";
        }
    }
}
