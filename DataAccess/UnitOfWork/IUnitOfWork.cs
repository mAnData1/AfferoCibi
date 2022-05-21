﻿using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public IMealRepository MealRepository { get; }

        public IOrderRepository OrderRepository { get; }

        Task SaveAsync();
    }
}
