using DataAccess.DTOs;
using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class AdminRepository : BaseRepository<AdminDTO>, IAdminRepository
    {
        public AdminRepository(AfferoCibiDBContextFactory contextFactory) 
            : base(contextFactory)
        {
        }
    }
}
