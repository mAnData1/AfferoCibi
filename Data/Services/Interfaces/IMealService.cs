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
        Task<Guid> GetIDAsync(Meal model);

        List<Meal> ToMeals(ICollection<MealDTO> mealsDTO);

        Task UpdateNameIncudedAsync(Guid id, Meal meal);
    }
}
