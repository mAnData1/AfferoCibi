using Data.Entities;
using Data.Services;
using Data.Services.Interfaces;
using Data.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public abstract class  BaseViewModelWithOrderService<TCurrentViewModel> : BaseHelpViewModel<TCurrentViewModel>
        where TCurrentViewModel : BaseViewModel
    {
        public readonly OrdersStore ordersStore;
        public BaseViewModelWithOrderService(NavigationService<HelpViewModel, TCurrentViewModel> helpNavigationService, OrdersStore ordersStore)
            : base(helpNavigationService)
        {
            this.ordersStore = ordersStore;
        }
        public abstract void LoadOrders(IEnumerable<Order> orders);
    }
}
