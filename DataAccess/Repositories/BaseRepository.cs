using DataAccess.DTOs;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class BaseRepository<DTO> : IBaseRepository<DTO> where DTO : BaseDTO
    {
        protected readonly AfferoCibiDBContext context;

        public BaseRepository(AfferoCibiDBContext context)
        {
            this.context = context;
        }

        public virtual async Task<ICollection<DTO>> GetAllAsync(Expression<Func<DTO, bool>>? filter = null)
        {
            var set = context.Set<DTO>().AsQueryable();

            if (filter != null)
            {
                set = set.Where(filter);
            }

            return await set.ToListAsync();
        }

        public virtual async ValueTask<DTO?> GetByIdAsync(Guid id)
        {
            return await context.Set<DTO>().FindAsync(id);
        }

        public virtual async Task CreateAsync(DTO entity)
        {
            context.Set<DTO>().Add(entity);
            await context.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(DTO entity)
        {
            var dbEntity = await GetByIdAsync(entity.Id);

            if (dbEntity == null)
            {
                throw new ArgumentException($"No such {typeof(DTO)} with id: {entity.Id}");
            }

            context.Entry(dbEntity).CurrentValues.SetValues(entity);

            await context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);

            if (entity == null)
            {
                throw new ArgumentException($"There is no such {typeof(DTO)} with id: {id}");
            }

            context.Set<DTO>().Remove(entity);

            await context.SaveChangesAsync();
        }

        public DTO? GetById(Guid id)
        {

            return context.Set<DTO>().Find(id);

        }

        public void Update(DTO entity)
        {
            context.Set<DTO>().Update(entity);
            context.SaveChanges();
        }
    }
}
