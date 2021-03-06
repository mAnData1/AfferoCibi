using Data.Entities.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Order
    {
        public string Address { get; set; }
        public virtual List<Meal> Meals { get; set; }

        public DateTime DateOfLastModified  { get; set; }

        public OrderStatus OrderStatus { get; set; } = OrderStatus.Processing;

        public Order(string address, DateTime modified)
        {
            Address = address;
            DateOfLastModified = modified;

        }
    }
}

