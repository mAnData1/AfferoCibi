using Data.Entities;
using Data.Services.Interfaces;
using DataAccess.DTOs;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class OrderService : BaseService<OrderDTO, Order, OrderRepository>, IOrderService
    {
        private readonly MealRepository mealRepository;
        public OrderService(OrderRepository repository, MealRepository mealRepository) : base(repository)
        {
            this.mealRepository = mealRepository;
        }

        public override async Task<OrderDTO> OnBeforeCreate(Order model)
        {

            return new OrderDTO
            {
                Id = new Guid(),
                DateOfLastModified = DateTime.Now,
                Address = model.Address,
                Meals = await GetMeals(model.Meals)
            };
        }
 
        private async Task<List<MealDTO>> GetMeals(List<Meal> meals)
        {
            List<MealDTO> result = new List<MealDTO>();

            foreach (var meal in meals)
            {
                result.Add(mealRepository.GetById(await mealRepository.GetIdThroughNameAsync(meal.Name)));
            }

            return result;
        }
    }
}
