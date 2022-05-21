using Data.Stores;
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
        protected OrdersStore ordersStore;
        protected FulfillingOrdersViewModel fulfillingOrdersViewModel;
        protected OrderViewModel selcetedOrder;

        public BaseFulfilOrdersCommand(FulfillingOrdersViewModel fulfillingOrdersViewModel, OrdersStore ordersStore)
        {
            enabled = false;
            this.fulfillingOrdersViewModel = fulfillingOrdersViewModel;
            fulfillingOrdersViewModel.PropertyChanged += SelectedOrderChanged;
            this.ordersStore = ordersStore;
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

            fulfillingOrdersViewModel.ShowMeals(selcetedOrder);
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
