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

        public DbSet<MealDTO> Meals { get; set; }

        public DbSet<AdminDTO> Admins { get; set; }

        public DbSet<OrderDTO> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MealDTO>().
                Property(m => m.Price).
                HasColumnType("decimal(10,2)");
              
            modelBuilder.Entity<MealDTO>().
                HasIndex(m => m.Name);
        }
    }
}
