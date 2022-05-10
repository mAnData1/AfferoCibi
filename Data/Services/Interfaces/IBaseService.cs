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
        Task Create(TModel model);
        Task Delete(Guid id);
        ValueTask<TModel> GetByIdAsync(Guid id);
        Task<TDTO> OnBeforeCreate(TModel model);
        Task<TDTO> OnBeforeUpdate(TModel model);
        Task Update(TModel model);
        Task<List<TModel>> GetAllAsync(Expression<Func<TModel, bool>>? filter = null);
    }
}
