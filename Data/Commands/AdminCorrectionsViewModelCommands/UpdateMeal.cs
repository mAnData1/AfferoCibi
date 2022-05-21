using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Commands
{
    public class UpdateMeal : BaseCommand
    {
        private AdminCorrectionsViewModel adminCorrectionsViewModel;

        //public override bool CanExecute(object? parameter)
        //{
            
        //    {
        //        return false && base.CanExecute(parameter);
        //    }
        //    else
        //    return true && base.CanExecute(parameter);
        //}
        public override void Execute(object? parameter)
        {
           ;
            adminCorrectionsViewModel.AddMealCommand.Enabled = false;
            adminCorrectionsViewModel.SaveChangesCommand.Enabled = true;
            
        }
        public UpdateMeal(AdminCorrectionsViewModel adminCorrectionsViewModel)
        {
            this.adminCorrectionsViewModel = adminCorrectionsViewModel;
            
        }
    }
}
