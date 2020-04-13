using DeliverySystem.Data.EF;
using DeliverySystem.Data.Entities;
using DeliverySystem.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeliverySystem.Data.Repositories
{
    public class DishRepository : IRepository<Dish>
    {
        private DeliveryContext db;

        public DishRepository(DeliveryContext context)
        {
            this.db = context;
        }

        public Guid Create(Dish item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Dish> Find(Func<Dish, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Dish Get(Guid id)
        {
            return db.Dishes.Find(id);
        }

        public IEnumerable<Dish> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Dish dish)
        {
            try
            {
                var exDish = db.Dishes.Find(dish.Id);

                db.Entry(exDish).State = EntityState.Detached;
                db.Dishes.Attach(dish);
                db.Entry(dish).State = EntityState.Modified;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
