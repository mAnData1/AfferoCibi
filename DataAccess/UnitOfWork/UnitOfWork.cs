using DataAccess.Repositories;
using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AfferoCibiDBContextFactory dbFactory;
        private readonly AfferoCibiDBContext db;
        private readonly IMealRepository mealRepository;
        private readonly IOrderRepository orderRepository;
        public UnitOfWork(AfferoCibiDBContextFactory dbFactory)
        {
            db = dbFactory.CreateDbContext();
            this.dbFactory = dbFactory;
            mealRepository = new MealRepository(dbFactory);
            orderRepository = new OrderRepository(dbFactory);
        }

        public IMealRepository MealRepository { get { return mealRepository; } }       

        public IOrderRepository OrderRepository { get { return orderRepository; } }

        public async Task SaveAsync()
        {
           await db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
        }
    }
}
