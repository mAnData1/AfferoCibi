using DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        void Create(T entity);
        void Delete(Guid id);
        ICollection<T> GetAll(Expression<Func<T, bool>>? filter = null);
        T? GetById(Guid id);
        void Update(T entity);
    }
}
