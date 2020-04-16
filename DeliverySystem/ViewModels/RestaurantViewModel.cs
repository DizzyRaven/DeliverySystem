using System;
using System.Collections.Generic;

namespace DeliverySystem.ViewModels
{
    /// <summary>
    /// Represents restaurant
    /// </summary>
    public class RestaurantViewModel
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Restaurant name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Restaurant physical address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Restaurant image. Could be photo or logo
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Dishes that cooked in this restaurant
        /// </summary>
        public List<DishViewModel> Dishes { get; set; }
    }
}