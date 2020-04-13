using DeliverySystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliverySystem.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Order> Orders { get; }
        IRepository<Restaurant> Restaurants { get; }
        IRepository<Dish> Dishes { get; }
        //IRepository<Courier> Couriers { get; }
        void Save();
    }
}
