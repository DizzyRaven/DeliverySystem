using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DeliverySystem.Logic.DTOs;
using DeliverySystem.Logic.Interfaces;
using DeliverySystem.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeliverySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IDeliveryService _deliveryService;
        private readonly IMapper _mapper;

        public ClientController(IDeliveryService deliveryService, IMapper mapper)
        {
            _deliveryService = deliveryService;
            _mapper = mapper;
        }
        [Route("restaurant")]
        [HttpGet]
        public ActionResult<IEnumerable<RestaurantViewModel>> GetRestaurants()
        {
            var restaurants = _deliveryService.GetRestaurants().Select(x => _mapper.Map<RestaurantViewModel>(x));
            return Ok(restaurants);
            //return new List<RestaurantViewModel>() { new RestaurantViewModel() { Id = Guid.NewGuid(), Address = "Skovorody st. 33" ,
            //    Name = "McDonalds" , ImageUrl = "https://delo.ua/files/news/images/3535/14/picture2_mcdonalds-otkryla_353514_p0.jpg",
            //Dishes = new List<DishViewModel>() { new DishViewModel() { Name = "Chessburger", Price = 33 } } } };
        }

        [HttpGet("restaurant/{id}")]
        public ActionResult<RestaurantViewModel> GetDishes(string id)
        {
            var restId = Guid.Parse(id);
            var restDto = _deliveryService.GetRestaurant(restId);
            var rest = _mapper.Map<RestaurantViewModel>(restDto);
            return Ok(rest);
            //return new RestaurantViewModel()
            //{
            //    Id = Guid.NewGuid(),
            //    Address = "Skovorody st. 33",
            //    Name = "McDonalds",
            //    ImageUrl = "https://delo.ua/files/news/images/3535/14/picture2_mcdonalds-otkryla_353514_p0.jpg",
            //    Dishes = new List<DishViewModel>() { new DishViewModel() { Name = "Chessburger", Price = 33 } }
            //};
        }

        [Route("orders")]
        [HttpGet]
        public ActionResult<IEnumerable<OrderViewModel>> GetOrders()
        {
            var orders = _deliveryService.GetOrders().Select(x=> _mapper.Map<OrderViewModel>(x));
            return Ok(orders);
            // return new List<OrderViewModel>() { new OrderViewModel() { Address = "Cvetaevoi 21 B", Name = "Vasya" } };
        }

        [HttpGet("orders/{id}")]
        public ActionResult<OrderViewModel> GetOrder(string id)
        {
            var orderId = Guid.Parse(id);
            var orderDto = _deliveryService.GetOrder(orderId);
            var order = _mapper.Map<OrderViewModel>(orderDto);
            return Ok(order);
            //return new OrderViewModel() { Address = "Cvetaevoi 21 B", Name = "Vasya" };
        }

        // Make order
        [HttpPost("orders")]
        public ActionResult<OrderViewModel> Post([FromBody]  OrderViewModel order)
        {
          var id =   _deliveryService.MakeOrder(_mapper.Map<OrderDto>(order));
            var response = new OrderViewModel() { Id = id };
            return response;

        }
    }
}