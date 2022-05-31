using Data.Entities;
using Data.Entities.enums;
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
            var DTOs = await unitOfWork.OrderRepository.GetAllAsync();

            return ToOrders(DTOs);
        }

        public async Task<OrderDTO> OnBeforeCreateAsync(Order model)
        {
            return new OrderDTO
            {
                Id = new Guid(),
                DateOfLastModified = DateTime.Now,
                Address = model.Address,
                OrderStatus = model.OrderStatus.ToString(),
                Meals = await GetMeals(model.Meals)
            };
        }

        public async Task<OrderDTO> OnBeforeUpdateAsync(Order model)
        {
            return new OrderDTO
            {
                Id = await unitOfWork.OrderRepository.GetIdThroughAddress(model.Address),
                DateOfLastModified = model.DateOfLastModified,
                Address = model.Address,
                Meals = await GetMeals(model.Meals),
                OrderStatus = model.OrderStatus.ToString()
            };
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

        private List<Meal> ToMeals(List<MealDTO> mealDTOs)
        {
            List<Meal> result = new List<Meal>();
            foreach (var meal in mealDTOs)
            {
                result.Add(new Meal(meal.MealImage, meal.Name, meal.Price, meal.Ingredients));
            }
            return result;
        }

        private OrderStatus SetOrderStatus(string status)
        {
            if (status == "Processing")
            {
                return OrderStatus.Обработване;
            }
            else if (status == "Sent")
            {
                return OrderStatus.Изпратена;
            }
            else if (status == "Rejected")
            {
                return OrderStatus.Отказана;
            }
            else
                throw new Exception("Invalid status");
        }

        public List<Order> ToOrders(ICollection<OrderDTO> orders)
        {
            List<Order> result = new List<Order>();
            foreach (var order in orders)
            {
                result.Add(new Order(order.Address, order.DateOfLastModified)
                {
                    OrderStatus = SetOrderStatus(order.OrderStatus),
                    Meals = ToMeals(order.Meals.ToList())
                });
            }
            return result;
        }
    }
}
