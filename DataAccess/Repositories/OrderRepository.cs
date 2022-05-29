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
    public class OrderRepository : BaseRepository<OrderDTO>, IOrderRepository
    {
        public OrderRepository(AfferoCibiDBContextFactory contextFactory) : 
            base(contextFactory)
        {
        }
        public override async Task<ICollection<OrderDTO>> GetAllAsync(Expression<Func<OrderDTO, bool>>? filter = null)
        {
            var set = dbSet.AsQueryable();

            if (filter != null)
            {
                set = set.Where(filter);
            }

            return await set.Include(o => o.Meals).ToListAsync();
        }

        public async Task<Guid> GetIdThroughAddress(string address)
        {
            OrderDTO orderDTO = await dbSet.FirstOrDefaultAsync(x => x.Address == address);

            return orderDTO.Id;
        }
    }
}
