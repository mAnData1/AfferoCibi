using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AfferoCibiDesingTimeDbContextFactory : IDesignTimeDbContextFactory<AfferoCibiDBContext>
    {
        public AfferoCibiDBContext CreateDbContext(string[] args)
        {
           DbContextOptions<AfferoCibiDBContext> options = new DbContextOptionsBuilder<AfferoCibiDBContext>()
                .UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = LiteraDB").Options;

            return new AfferoCibiDBContext(options);
        }
    }
}
