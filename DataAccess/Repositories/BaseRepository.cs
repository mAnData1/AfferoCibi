using DataAccess.DTOs;
using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        protected readonly AfferoCibiDBContext context;

        public BaseRepository(AfferoCibiDBContext context)
        {
            this.context = context;
        }
        public void Create(T entity)
        {

            context.Set<T>().Add(entity);
            context.SaveChanges();

        }

        public void Delete(Guid id)
        {


            var entity = GetById(id);
            if (entity == null)
            {
                throw new ArgumentException("");
            }
            context.Set<T>().Remove(entity);
            context.SaveChanges();


        }

        public ICollection<T> GetAll(Expression<Func<T, bool>>? filter = null)
        {

            var set = context.Set<T>().AsQueryable();
            if (filter != null)
            {
                set = set.Where(filter);
            }
            return set.ToList();


        }

        public T? GetById(Guid id)
        {

            return context.Set<T>().Find(id);

        }

        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
            context.SaveChanges();
        }
    }
}
