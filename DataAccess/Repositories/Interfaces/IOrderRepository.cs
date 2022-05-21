using DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface IOrderRepository : IBaseRepository<OrderDTO>
    {
        public Task<Guid> GetIdThroughAddress(string address);
    }
}
