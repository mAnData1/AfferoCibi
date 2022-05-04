using Data.Commands;
using Data.Commands.AdminCorrectionsViewModelCommands;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public class MealCardAdminViewModel : MealViewModel
    {
        public MealCardAdminViewModel(Meal meal, AdminCorrectionsViewModel adminCorrectionsViewModel) 
            : base(meal)
        {
            UpdateCommand = new UpdateMeal(adminCorrectionsViewModel,this);
            DeleteCommand = new DeleteMeal(adminCorrectionsViewModel, this);
        }

        public BaseCommand UpdateCommand { get; }
        public BaseCommand DeleteCommand { get; }
    }
}
