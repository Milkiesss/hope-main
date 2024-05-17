using Application.DTOs.OrderDto;
using Application.DTOs.OrderDto.Request;
using Application.DTOs.OrderDto.Responce;
using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class OrderMapProfile : Profile
    {
        public OrderMapProfile()
        {
            CreateMap<BaseItemOrderDto, ItemOrder>();
            CreateMap<ItemOrder, BaseItemOrderDto>();

            CreateMap<OrderCreateRequest, Order>();


            CreateMap<OrderUpdateRequest, Order>();


            CreateMap<Order, OrderGetAllResponce>()
                .ForMember(dest => dest.items, opt => opt.MapFrom(Src => Src.items));

            CreateMap<Order, OrderGetByIdResponce>()
                .ForMember(dest => dest.items, opt => opt.MapFrom(Src => Src.items));


            CreateMap<Order, OrderCreateResponce>()
                 .ForMember(dest => dest.items, opt => opt.MapFrom(Src => Src.items));
            CreateMap<Order, OrderUpdateResponce>()
                 .ForMember(dest => dest.items, opt => opt.MapFrom(Src => Src.items));

        }
    }
}
