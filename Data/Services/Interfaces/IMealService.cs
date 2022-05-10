using Data.Entities;
using DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.Interfaces
{
    public interface IMealService : IBaseService<MealDTO,Meal>
    {
        Task<Guid> GetID(Meal model);

        Task<List<Meal>> ToMeals();

        Task UpdateNameIncuded(Guid id, Meal meal);
    }
}
