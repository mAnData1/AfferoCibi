using DataAccess.DTOs;
using DataAccess.Repositories.Interfaces;
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
    }
}
