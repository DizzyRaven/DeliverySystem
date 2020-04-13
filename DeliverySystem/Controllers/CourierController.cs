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
    public class CourierController : ControllerBase
    {
        private readonly IDeliveryService _deliveryService;
        private readonly IMapper _mapper;
        public CourierController(IDeliveryService deliveryService, IMapper mapper)
        {
            _deliveryService = deliveryService;
            _mapper = mapper;
        }

        [Route("orders")]
        [HttpGet]
        public ActionResult<IEnumerable<OrderViewModel>> Get()
        {
            var orders = _deliveryService.GetOrders().Select(x => _mapper.Map<OrderViewModel>(x));
            return Ok(orders);
        }
        [HttpGet("orders/{id}")]
        public ActionResult<OrderViewModel> Get(string id)
        {
            var orderId = Guid.Parse(id);
            var orderDto = _deliveryService.GetOrder(orderId);
            var order = _mapper.Map<OrderViewModel>(orderDto);
            return Ok(order);
        }

        //change status
        [HttpPost("orders/{id}")]
        public ActionResult<OrderViewModel> Post([FromBody]  OrderViewModel order, [FromHeader] Guid id)
        {
            _deliveryService.MakeOrder(_mapper.Map<OrderDto>(order));

            return Ok(order);
        }
    }
}