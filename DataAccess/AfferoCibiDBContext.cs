using DataAccess.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AfferoCibiDBContext : DbContext
    {
        public AfferoCibiDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<MealDTO> meals { get; set; }

        public DbSet<AdminDTO> Admins { get; set; }

        public DbSet<OrderDTO> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MealDTO>().
                HasOne(m => m.Order).
                WithMany(o => o.Meals).
                HasForeignKey(m => m.OrderId);
            modelBuilder.Entity<MealDTO>().
                HasIndex(m => m.Name);
        }
    }
}
