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

        public DateTime DateOfLastModified
        { 
            get {return order.DateOfLastModified;}
            set { order.DateOfLastModified = value;}
        }
        public OrderStatus OrderStatus
        {
            get {return order.OrderStatus;}
            set { order.OrderStatus = value;}
        }
        public string Address 
        { 
            get { return order.Address;} 
            set { order.Address = value;} 
        }
        public OrderViewModel(Order order)
        {
                this.order = order;
        }
    }
}
