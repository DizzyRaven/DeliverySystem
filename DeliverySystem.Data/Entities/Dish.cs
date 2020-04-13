using System;
using System.Collections.Generic;
using System.Text;

namespace DeliverySystem.Data.Entities
{
    public class Dish
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }

        public Guid RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        // public List<Order> Orders { get; set; }
        public Guid? OrderId { get; set; }

        public Order Order { get; set; }
    }
}
