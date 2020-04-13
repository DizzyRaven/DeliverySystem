using AutoMapper;
using DeliverySystem.Data.Entities;
using DeliverySystem.Logic.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliverySystem.Logic.Helpers
{
    public static class Mapping
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg => {
                // This line ensures that internal properties are also mapped over.
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<MappingProfile>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper => Lazy.Value;
    }

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Dish, DishDto>();
            CreateMap<Order, OrderDto>();
            CreateMap<Restaurant, RestaurantDto>();

            CreateMap<DishDto, Dish>();
            CreateMap<OrderDto, Order>();


        }
    }
}
