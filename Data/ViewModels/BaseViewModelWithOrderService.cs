using Data.Entities;
using Data.Services;
using Data.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public abstract class  BaseViewModelWithOrderService : BaseHelpViewModel
    {
        public readonly IOrderService orderService;
        public BaseViewModelWithOrderService(NavigationService helpNavigationService, IOrderService orderService)
            : base(helpNavigationService)
        {
            this.orderService = orderService;
        }

        public abstract void LoadOrders(ICollection<Order> orders);
    }
}
