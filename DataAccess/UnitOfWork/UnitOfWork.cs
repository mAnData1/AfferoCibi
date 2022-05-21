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
        private readonly AfferoCibiDBContext db;
        private readonly IMealRepository mealRepository;
        private readonly IOrderRepository orderRepository;
        public UnitOfWork(AfferoCibiDBContext db)
        {
            this.db = db;
            mealRepository = new MealRepository(db);
            orderRepository = new OrderRepository(db);
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
