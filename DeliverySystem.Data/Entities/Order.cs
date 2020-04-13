using System;
using System.Collections.Generic;
using System.Text;

namespace DeliverySystem.Data.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Moblie { get; set; }
        public string OrderStatus { get; set; }


        public ICollection<Dish> Dishes { get; set; }

        public DateTime CreationDate { get; set; }

        public Guid? CourierId { get; set; }
        public Courier Courier { get; set; }
    }
}
