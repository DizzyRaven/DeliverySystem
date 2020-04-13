using DeliverySystem.Data.EF;
using DeliverySystem.Data.Entities;
using DeliverySystem.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeliverySystem.Data.Repositories
{
    public class RestaurantRepository : IRepository<Restaurant>
    {
        private DeliveryContext db;

        public RestaurantRepository(DeliveryContext context)
        {
            this.db = context;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return db.Restaurants.Include(o => o.Dishes);
        }

        public Restaurant Get(Guid id)
        {
            return db.Restaurants.Where(x => x.Id == id).Include(o => o.Dishes).FirstOrDefault();
        }

        public Guid Create(Restaurant r)
        {
            throw new NotImplementedException();
        }

        public void Update(Restaurant r)
        {
            db.Entry(r).State = EntityState.Modified;
        }
        public IEnumerable<Restaurant> Find(Func<Restaurant, Boolean> predicate)
        {
            return db.Restaurants.Include(o => o.Dishes).Where(predicate).ToList();
        }
        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
