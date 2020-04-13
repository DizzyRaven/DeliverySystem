using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliverySystem.Logic.DTOs
{
    public class DishDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public Guid RestaurantId { get; set; }


        public Guid? OrderId { get; set; }
    }
}
