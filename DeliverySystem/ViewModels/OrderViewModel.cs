using System;
using System.Collections.Generic;

namespace DeliverySystem.ViewModels
{
    /// <summary>
    /// Model for order
    /// </summary>
    public class OrderViewModel
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Customer's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Delivery Address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Customer phone number
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// Status of order. Could be "New", "Cooking", "Delivering" and "Done"
        /// </summary>
        public string OrderStatus { get; set; }

        /// <summary>
        /// Date and time when order was made
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Dishes, that in this order
        /// </summary>
        public List<DishViewModel> Dishes { get; set; }
    }
}