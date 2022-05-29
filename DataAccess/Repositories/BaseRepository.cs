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
        protected readonly AfferoCibiDBContextFactory contextFactory;
        protected readonly AfferoCibiDBContext context;
        protected readonly DbSet<DTO> dbSet;
        public BaseRepository(AfferoCibiDBContextFactory contextFactory)
        {
            this.context = contextFactory.CreateDbContext();
            dbSet = context.Set<DTO>();
        }

        public virtual async Task<ICollection<DTO>> GetAllAsync(Expression<Func<DTO, bool>>? filter = null)
        {
            var set = dbSet.AsQueryable();

            if (filter != null)
            {
                set = set.Where(filter);
            }

            return await set.ToListAsync();
        }

        public virtual async ValueTask<DTO?> GetByIdAsync(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task CreateAsync(DTO entity)
        {
            dbSet.Add(entity);
        }

        public virtual async Task UpdateAsync(DTO entity)
        {
            var dbEntity = await GetByIdAsync(entity.Id);

            if (dbEntity == null)
            {
                throw new ArgumentException($"No such {typeof(DTO)} with id: {entity.Id}");
            }

            context.Entry(dbEntity).CurrentValues.SetValues(entity);

        }

        public virtual async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);

            if (entity == null)
            {
                throw new ArgumentException($"There is no such {typeof(DTO)} with id: {id}");
            }

            dbSet.Remove(entity);
        }

        public DTO? GetById(Guid id)
        {

            return dbSet.Find(id);

        }

        public void Update(DTO entity)
        {
            dbSet.Update(entity);
        }
    }
}
