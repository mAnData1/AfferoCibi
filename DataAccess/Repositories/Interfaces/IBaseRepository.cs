using DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : BaseDTO
    {
        Task CreateAsync(T entity);
        Task DeleteAsync(Guid id);
        Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null);
        ValueTask<T?> GetByIdAsync(Guid id);
        Task UpdateAsync(T entity);
    }
}
