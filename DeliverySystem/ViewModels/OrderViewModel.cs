﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliverySystem.ViewModels
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public string Moblie { get; set; }
        public string OrderStatus { get; set; }
        public DateTime CreationDate { get; set; }


        public List<DishViewModel> Dishes { get; set; }
    }
}
