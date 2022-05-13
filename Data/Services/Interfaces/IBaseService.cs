using DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.Interfaces
{
    public interface IBaseService<TDTO, TModel>
         where TDTO : BaseDTO
         where TModel : class
    {
        Task CreateAsync(TModel model);
        Task DeleteAsync(TModel model);
        Task<TDTO> OnBeforeCreateAsync(TModel model);
        Task<TDTO> OnBeforeUpdateAsync(TModel model);
        Task UpdateAsync(TModel model);
        Task<ICollection<TModel>> GetAllAsync(Expression<Func<TModel, bool>>? filter = null);
    }
}
