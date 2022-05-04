using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Commands.FulfilingOrderCommands
{
    public class BaseFulfilOrdersCommand : BaseCommand
    {

        protected FulfillingOrdersViewModel fulfillingOrdersViewModel;

        protected OrderViewModel selcetedOrder;

        public BaseFulfilOrdersCommand(FulfillingOrdersViewModel fulfillingOrdersViewModel)
        {
            enabled = false;
            this.fulfillingOrdersViewModel = fulfillingOrdersViewModel;
            fulfillingOrdersViewModel.PropertyChanged += SelectedOrderChanged;
        }

        private void SelectedOrderChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(fulfillingOrdersViewModel.SelectedOrderIndex))
            {
                OnExecutedChanged();
                if (fulfillingOrdersViewModel.SelectedOrderIndex != -1)
                {
                    selcetedOrder =  fulfillingOrdersViewModel.Orders[fulfillingOrdersViewModel.SelectedOrderIndex];
                }
            }

        }
        public override void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }

        public override bool CanExecute(object? parameter)
        {
            if (fulfillingOrdersViewModel.SelectedOrderIndex != -1)
            {
                enabled = true;
                return
                    enabled
                    && base.CanExecute(parameter);
            }
            enabled = false;

            return enabled
                && base.CanExecute(parameter);
        }

    }
}
