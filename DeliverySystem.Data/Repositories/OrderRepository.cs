using DeliverySystem.Data.EF;
using DeliverySystem.Data.Entities;
using DeliverySystem.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeliverySystem.Data.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private DeliveryContext db;

        public OrderRepository(DeliveryContext context)
        {
            this.db = context;
        }

        public IEnumerable<Order> GetAll()
        {
            return db.Orders.Include(o => o.Dishes);
        }

        public Order Get(Guid id)
        {
            return db.Orders.Where(x => x.Id == id).Include(o => o.Dishes).FirstOrDefault();
        }

        public Guid Create(Order order)
        {
            order.Id = Guid.NewGuid();
            order.Dishes = null;
            db.Orders.Add(order);

            return order.Id;
        }
        public void AsignCourier(Courier courier)
        {
            try
            {
                var exCourier = db.Couriers.Find(courier.Id);

                db.Entry(exCourier).State = EntityState.Detached;
                db.Couriers.Attach(courier);
                db.Entry(courier).State = EntityState.Modified;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Update(Order order)
        {
            try
            {
                var exOrder = db.Orders.Find(order.Id);

                db.Entry(exOrder).State = EntityState.Detached;
                db.Orders.Attach(order);
                db.Entry(order).State = EntityState.Modified;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public IEnumerable<Order> Find(Func<Order, Boolean> predicate)
        {
            return db.Orders.Include(o => o.Dishes).Where(predicate).ToList();
        }
        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
