using Data.Entities;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Commands
{
    public class LoadOrders<TViewModel> : BaseAsyncCommand where TViewModel : BaseViewModelWithOrderService
    {
        private readonly TViewModel viewModel;
        public LoadOrders(TViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public override async Task ExecuteAsync(object? parameter)
        {
            ICollection<Order> orders = await viewModel.orderService.GetAllAsync();

            viewModel.LoadOrders(orders);
        }
    }
}
