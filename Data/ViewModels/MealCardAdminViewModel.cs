using Data.Commands;
using Data.Commands.AdminCorrectionsViewModelCommands;
using Data.Entities;
using Data.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public class MealCardAdminViewModel : MealViewModel
    {
        private readonly MealsStore mealsStore;
        public MealCardAdminViewModel(Meal meal, AdminCorrectionsViewModel adminCorrectionsViewModel, MealsStore mealsStore) 
            : base(meal)
        {
            this.mealsStore = mealsStore;

            UpdateCommand = new UpdateMeal(adminCorrectionsViewModel, this, mealsStore);
            DeleteCommand = new DeleteMeal(adminCorrectionsViewModel, this, mealsStore);
        }
        public BaseCommand UpdateCommand { get; }
        public BaseCommand DeleteCommand { get; }
    }
}
