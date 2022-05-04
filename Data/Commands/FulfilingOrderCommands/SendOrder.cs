using Data.Entities.enums;
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
        public SendOrder(FulfillingOrdersViewModel fulfillingOrdersViewModel) 
            : base(fulfillingOrdersViewModel)
        {
        }
        public override void Execute(object? parameter)
        {
            selcetedOrder.OrderStatus = OrderStatus.Sent;
            selcetedOrder.DateOfLastModified = DateTime.Now;

            fulfillingOrdersViewModel.Orders.Insert(fulfillingOrdersViewModel.SelectedOrderIndex, selcetedOrder);
            fulfillingOrdersViewModel.Orders.RemoveAt(fulfillingOrdersViewModel.SelectedOrderIndex);

        }
    }
}
