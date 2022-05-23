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
    public class MealService : IMealService
    {
        private readonly IUnitOfWork unitOfWork;
        public MealService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<MealDTO> OnBeforeCreateAsync(Meal model)
        {
            return new MealDTO
            {
                Id = new Guid(),
                MealImage = model.MealImage,
                Name = model.Name,
                Ingredients = model.Ingredients,
                Price = model.Price
            };
        }
        public async Task<MealDTO> OnBeforeUpdateAsync(Meal model)
        {
            return new MealDTO
            {
                Id = await GetIDAsync(model),
                MealImage = model.MealImage,
                Name = model.Name,
                Ingredients = model.Ingredients,
                Price = model.Price
            };
        }

        public async Task<ICollection<Meal>> GetAllAsync(Expression<Func<Meal, bool>>? filter = null)
        {
            var mealDTOs = await unitOfWork.MealRepository.GetAllAsync();
            return ToMeals(mealDTOs);
        }


        public async Task<Guid> GetIDAsync(Meal model)
        {
            return await unitOfWork.MealRepository.GetIdThroughNameAsync(model.Name);
        }

        public List<Meal> ToMeals(ICollection<MealDTO> mealDTOs)
        {
            return mealDTOs.Select(mDTO => new Meal(mDTO.MealImage, mDTO.Name, mDTO.Price, mDTO.Ingredients)).ToList();
        }

        public async Task UpdateNameIncudedAsync(Guid id, Meal meal)
        {
            MealDTO dTO = new MealDTO
            {
                Id = id,
                Name = meal.Name,
                Price = meal.Price,
                Ingredients = meal.Ingredients,
            };
            await unitOfWork.MealRepository.UpdateAsync(dTO);
            await unitOfWork.SaveAsync();
        }

        public async Task CreateAsync(Meal model)
        {
            await unitOfWork.MealRepository.CreateAsync(await OnBeforeCreateAsync(model));
            await unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(Meal model)
        {
            Guid id = await unitOfWork.MealRepository.GetIdThroughNameAsync(model.Name);
            await unitOfWork.MealRepository.DeleteAsync(id);
            await unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(Meal model)
        {
            await unitOfWork.MealRepository.UpdateAsync(await OnBeforeUpdateAsync(model));
            await unitOfWork.SaveAsync();
        }
    }
}
