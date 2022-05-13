using Data.Entities;
using Data.Services.Interfaces;
using DataAccess.DTOs;
using DataAccess.Repositories;
using DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task CreateAsync(Order model)
        {
            await unitOfWork.OrderRepository.CreateAsync(await OnBeforeCreateAsync(model));
            await unitOfWork.SaveAsync();
        }

        public Task DeleteAsync(Order model)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Order>> GetAllAsync(Expression<Func<Order, bool>>? filter = null)
        {
           return (ICollection<Order>)await unitOfWork.OrderRepository.GetAllAsync();

        }

        public async Task<OrderDTO> OnBeforeCreateAsync(Order model)
        {
            return new OrderDTO
            {
                Id = new Guid(),
                DateOfLastModified = DateTime.Now,
                Address = model.Address,
                Meals = await GetMeals(model.Meals)
            };
        }

        public Task<OrderDTO> OnBeforeUpdateAsync(Order model)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Order model)
        {
            await unitOfWork.OrderRepository.UpdateAsync(await OnBeforeUpdateAsync(model));
            await unitOfWork.SaveAsync();
        }

        public async Task<ICollection<MealDTO>> GetMeals(ICollection<Meal> meals)
        {
            ICollection<MealDTO> result = new List<MealDTO>();

            foreach (var meal in meals)
            {
                result.Add(await unitOfWork.MealRepository.GetByIdAsync(await unitOfWork.MealRepository.GetIdThroughNameAsync(meal.Name)));
            }

            return result;
        }
    }
}
