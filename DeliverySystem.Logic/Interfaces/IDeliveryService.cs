using DeliverySystem.Logic.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliverySystem.Logic.Interfaces
{
    public interface IDeliveryService
    {
        IEnumerable<RestaurantDto> GetRestaurants();
        RestaurantDto GetRestaurant(Guid id);
        IEnumerable<OrderDto> GetOrders();
        OrderDto GetOrder(Guid id);
        Guid MakeOrder(OrderDto order);


    }
}
