using System;
using System.Collections.Generic;
using System.Text;

namespace DeliverySystem.Data.Entities
{
   public  class Restaurant
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<Dish> Dishes { get; set; }
    }
}
