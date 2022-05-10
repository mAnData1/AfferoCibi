using Data.Entities;
using Data.Services.Interfaces;
using DataAccess.DTOs;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class MealService : BaseService<MealDTO, Meal, MealRepository>, IMealService
    {
        public MealService(MealRepository repository) : base(repository)
        {
        }

        public override async Task<MealDTO> OnBeforeCreate(Meal model)
        {
            return new MealDTO
            {
                Id = new Guid(),
                Name = model.Name,
                Ingredients = model.Ingredients,
                Price = model.Price
            };
        }
        public override async Task<MealDTO> OnBeforeUpdate(Meal model)
        {
            return new MealDTO
            {
                Id = await GetID(model),
                Name = model.Name,
                Ingredients = model.Ingredients,
                Price = model.Price
            };
        }

        public override async Task<List<Meal>> GetAllAsync(Expression<Func<Meal, bool>>? filter = null)
        {
            return await ToMeals();
        }


        public async Task<Guid> GetID(Meal model)
        {
            return await repository.GetIdThroughNameAsync(model.Name);
        }

        public async Task<List<Meal>> ToMeals()
        {
            ICollection<MealDTO> mealDTOs = await repository.GetAllAsync();
            return mealDTOs.Select(mDTO => new Meal(mDTO.MealImage, mDTO.Name, mDTO.Price, mDTO.Ingredients)).ToList();
        }

        public async Task UpdateNameIncuded(Guid id, Meal meal)
        {
            MealDTO dTO = new MealDTO
            {
                Id = id,
                Name = meal.Name,
                Price = meal.Price,
                Ingredients = meal.Ingredients,
            };
            await repository.UpdateAsync(dTO);
        }
    }
}
