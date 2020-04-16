using AutoMapper;
using DeliverySystem.Logic.DTOs;
using DeliverySystem.Logic.Interfaces;
using DeliverySystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeliverySystem.Controllers
{
    /// <summary>
    /// Controller for client needs only.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CourierController : ControllerBase
    {
        private readonly IDeliveryService _deliveryService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="deliveryService"> Implementation of class that allows to manipulate with order and their delivery</param>
        /// <param name="mapper">Mapper service to map DTO and ViewModel</param>
        public CourierController(IDeliveryService deliveryService, IMapper mapper)
        {
            _deliveryService = deliveryService;
            _mapper = mapper;
        }

        /// <summary>
        ///Returns all order in DB
        /// </summary>
        /// <returns></returns>
        [Route("orders")]
        [HttpGet]
        public ActionResult<IEnumerable<OrderViewModel>> Get()
        {
            var orders = _deliveryService.GetOrders().Select(x => _mapper.Map<OrderViewModel>(x));
            return Ok(orders);
        }

        /// <summary>
        /// Return order by Id
        /// </summary>
        /// <param name="id">ID of order in DB</param>
        /// <returns></returns>
        [HttpGet("orders/{id}")]
        public ActionResult<OrderViewModel> Get(string id)
        {
            var orderId = Guid.Parse(id);
            var orderDto = _deliveryService.GetOrder(orderId);
            var order = _mapper.Map<OrderViewModel>(orderDto);
            return Ok(order);
        }

        /// <summary>
        /// Allows to change order status
        /// </summary>
        /// <param name="order">Updated order model</param>
        /// <param name="id">Id of desired order</param>
        /// <returns></returns>
        [HttpPost("orders/{id}")]
        public ActionResult<OrderViewModel> Post([FromBody]  OrderViewModel order, [FromHeader] Guid id)
        {
            _deliveryService.MakeOrder(_mapper.Map<OrderDto>(order));

            return Ok(order);
        }
    }
}