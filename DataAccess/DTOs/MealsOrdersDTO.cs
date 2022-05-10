using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs
{
    public class MealsOrdersDTO : BaseDTO
    {
        public MealDTO? Meal { get; set; }
        public Guid? MealID { get; set; }

        public OrderDTO? Order { get; set; }
        public Guid? OrderID { get; set; } 
    }
}
