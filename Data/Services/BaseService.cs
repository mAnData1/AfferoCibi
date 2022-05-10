using Data.Services.Interfaces;
using DataAccess.DTOs;
using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class BaseService<TDTO, TModel, TRepository> : IBaseService<TDTO, TModel> where TDTO : BaseDTO
        where TModel : class
        where TRepository : IBaseRepository<TDTO>
    {
        protected readonly TRepository repository;

        public BaseService(TRepository repository)
        {
            this.repository = repository;
        }

        public virtual async Task Delete(Guid id)
        {
            await repository.DeleteAsync(id);
        }
        public virtual async Task<TDTO> OnBeforeCreate(TModel model)
        {
           throw new NotImplementedException();
        }

        public virtual async Task Create(TModel model)
        {
            var entity = await OnBeforeCreate(model);

            await repository.CreateAsync(entity);
        }

        public virtual async Task<TDTO> OnBeforeUpdate(TModel model)
        {
            throw new NotImplementedException();
        }

        public async virtual Task Update(TModel model)
        {
            var entity = await OnBeforeUpdate(model);

            await repository.UpdateAsync(entity);
        }

        public virtual async ValueTask<TModel> GetByIdAsync(Guid id)
        {
            var entity = await repository.GetByIdAsync(id);

            throw new NotImplementedException();
            
        }

        public virtual async Task<List<TModel>> GetAllAsync(Expression<Func<TModel, bool>>? filter = null)
        {
            var expression = filter;


            throw new NotImplementedException();
        }
    }
}
