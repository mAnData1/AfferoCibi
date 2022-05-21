using Data.Entities;
using DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.Interfaces
{
    public interface IOrderService : IBaseService<OrderDTO,Order>
    {
        Task<ICollection<MealDTO>> GetMeals(ICollection<Meal> meals);

        List<Order> ToOrders(ICollection<OrderDTO> orders);
    }
}
