using AutoMapper;
using DeliverySystem.Logic.DTOs;
using DeliverySystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliverySystem.Helpers
{
    public class MainProfile : Profile
    {
        public MainProfile()
        {
            CreateMap<DishDto, DishViewModel>();
            CreateMap<RestaurantDto, RestaurantViewModel>();
            CreateMap<OrderDto, OrderViewModel>();

            CreateMap<DishViewModel, DishDto>();

            CreateMap<OrderViewModel, OrderDto>();
        }
    }
}
