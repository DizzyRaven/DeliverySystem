using DeliverySystem.Data.EF;
using DeliverySystem.Data.Entities;
using DeliverySystem.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliverySystem.Data.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private DeliveryContext db;
        private OrderRepository orderRepository;
        private RestaurantRepository restaurantRepository;
        private DishRepository dishRepository;

        public EFUnitOfWork(DbContextOptions<DeliveryContext> options)
        {
            db = new DeliveryContext(options);
        }
        public IRepository<Restaurant> Restaurants
        {
            get
            {
                if (restaurantRepository == null)
                    restaurantRepository = new RestaurantRepository(db);
                return restaurantRepository;
            }
        }
        public IRepository<Dish> Dishes
        {
            get
            {
                if (dishRepository == null)
                    dishRepository = new DishRepository(db);
                return dishRepository;
            }
        }

        public IRepository<Order> Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(db);
                return orderRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
