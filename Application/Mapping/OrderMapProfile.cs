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
                //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                //.ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                //.ForMember(dest => dest.items, opt => opt.MapFrom(Src => Src.items));


            CreateMap<OrderUpdateRequest, Order>();
                //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                //.ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                //.ForMember(dest => dest.items, opt => opt.MapFrom(Src => Src.items));

            CreateMap<Order, OrderGetAllResponce>();
            CreateMap<Order, OrderGetByIdResponce>();

            CreateMap<Order, OrderCreateResponce>();
            CreateMap<Order, OrderUpdateResponce>();

        }
    }
}
