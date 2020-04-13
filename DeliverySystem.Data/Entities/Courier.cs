using System;
using System.Collections.Generic;
using System.Text;

namespace DeliverySystem.Data.Entities
{
   public class Courier
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsBussy { get; set; }

        public List<Order>  Orders { get; set; }
    }
}
