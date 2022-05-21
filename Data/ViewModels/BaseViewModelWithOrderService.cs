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
    public abstract class  BaseViewModelWithOrderService : BaseHelpViewModel
    {
        public readonly OrdersStore ordersStore;
        public BaseViewModelWithOrderService(NavigationService helpNavigationService, OrdersStore ordersStore)
            : base(helpNavigationService)
        {
            this.ordersStore = ordersStore;
        }
        public abstract void LoadOrders(IEnumerable<Order> orders);
    }
}
