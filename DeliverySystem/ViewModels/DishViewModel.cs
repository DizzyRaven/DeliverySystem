using System;

namespace DeliverySystem.ViewModels
{
    /// <summary>
    /// Model for dish
    /// </summary>
    public class DishViewModel
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// URL to dish photo/image
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Dish name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Dish price in UAH
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Unique identifier of restaurant which cook this dish
        /// </summary>
        public Guid RestaurantId { get; set; }
    }
}