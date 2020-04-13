using DeliverySystem.Data.Entities;
using DeliverySystem.Data.Interfaces;
using DeliverySystem.Logic.DTOs;
using DeliverySystem.Logic.Helpers;
using DeliverySystem.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeliverySystem.Logic.Services
{
    public class DeliveryService : IDeliveryService
    {
        IUnitOfWork Database { get; set; }

        public DeliveryService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<RestaurantDto> GetRestaurants()
        {
            return Database.Restaurants.GetAll().Select(x => Mapping.Mapper.Map<RestaurantDto>(x));
        }

        public RestaurantDto GetRestaurant(Guid id)
        {
            var rest = Database.Restaurants.Get(id);
            if (rest != null)
            {
                return Mapping.Mapper.Map<RestaurantDto>(rest);
            }
            return null;
        }

        public IEnumerable<OrderDto> GetOrders()
        {
            return Database.Orders.GetAll().Select(x => Mapping.Mapper.Map<OrderDto>(x)).OrderByDescending(x=> x.CreationDate);
        }

        public OrderDto GetOrder(Guid id)
        {
            var order = Database.Orders.Get(id);
            if (order != null)
            {
                return Mapping.Mapper.Map<OrderDto>(order);
            }
            return null;
        }

        public Guid MakeOrder(OrderDto orderDto)
        {
            var order = Database.Orders.Get(orderDto.Id);
            foreach (var dish in orderDto.Dishes)
            {


            }
            Guid orderId = orderDto.Id;
            if (order != null)
            {
                if (orderDto.OrderStatus != null)
                {
                    order.OrderStatus = orderDto.OrderStatus;
                }
                Database.Orders.Update(order);
            }
            else
            {
                orderDto.CreationDate = DateTime.Now;
                orderId = Database.Orders.Create(Mapping.Mapper.Map<Order>(orderDto));

            }
            foreach (var dish in orderDto.Dishes)
            {
                var d = Database.Dishes.Get(dish.Id);

                if (dish == null)
                {
                    throw new ArgumentException("No such dish was found");
                }

                d.OrderId = orderId;
                Database.Dishes.Update(Mapping.Mapper.Map<Dish>(d));
                Database.Save();

            }
            return orderId;

        }
    }
}
