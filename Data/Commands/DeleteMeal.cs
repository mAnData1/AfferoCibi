using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Commands
{
    public class DeleteMeal : BaseCommand
    {
        private AdminCorrectionsViewModel adminCorrectionsViewModel;

        public override void Execute(object? parameter)
        {
            
        }

        //public override bool CanExecute(object? parameter)
        //{
        //    if (adminCorrectionsViewModel.SelectedMeal == null)
        //    {
        //        return false && Enabled && base.CanExecute(parameter);
        //    }
        //    else
        //        return true && Enabled && base.CanExecute(parameter);
        //}

        public DeleteMeal(AdminCorrectionsViewModel adminCorrectionsViewModel)
        {
            this.adminCorrectionsViewModel = adminCorrectionsViewModel;
        }

    }
}
