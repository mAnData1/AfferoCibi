using Data.Entities;
using Data.Entities.enums;
using Data.Stores;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Commands.FulfilingOrderCommands
{
    public class SendOrder : BaseFulfilOrdersCommand
    {
        public SendOrder(FulfillingOrdersViewModel fulfillingOrdersViewModel, OrdersStore ordersStore) 
            : base(fulfillingOrdersViewModel, ordersStore)
        {
        }
        public override void Execute(object? parameter)
        {
            selcetedOrder.OrderStatus = OrderStatus.Изпратена;
            selcetedOrder.DateOfLastModified = DateTime.Now;

            ordersStore.Update(selcetedOrder.ViewModelToModel(selcetedOrder));

            fulfillingOrdersViewModel.Orders.Insert(fulfillingOrdersViewModel.SelectedOrderIndex, selcetedOrder);
            fulfillingOrdersViewModel.Orders.RemoveAt(fulfillingOrdersViewModel.SelectedOrderIndex);

        }

    }
}
