using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AfferoCibiDBContextFactory
    {
        private readonly string _connectionString;

        public AfferoCibiDBContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public AfferoCibiDBContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlServer(_connectionString).Options;

            return new AfferoCibiDBContext(options);
        }
    }
}
