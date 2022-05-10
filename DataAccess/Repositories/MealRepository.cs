using DataAccess.DTOs;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class MealRepository : BaseRepository<MealDTO>, IMealRepository
    {
        public MealRepository(AfferoCibiDBContext context) 
            : base(context)
        {
        }
        public async Task<Guid> GetIdThroughNameAsync(string name)
        {
            MealDTO mealDTO = await context.Set<MealDTO>().FirstAsync(x => x.Name == name);

            return mealDTO.Id;
        }
    }
}
