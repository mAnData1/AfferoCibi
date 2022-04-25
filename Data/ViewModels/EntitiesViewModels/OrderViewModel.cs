using Data.Entities;
using Data.Entities.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public class OrderViewModel : BaseViewModel
    {
        private Order order;

        public Guid Id => order.Id;
        public DateTime DateOfLastModified => order.DateOfLastModified;
        public OrderStatus OrderStatus => order.OrderStatus;    

        public OrderViewModel(Order order)
        {
                this.order = order;
        }
    }
}
