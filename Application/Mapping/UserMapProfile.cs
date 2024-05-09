﻿using Application.DTOs.CategoryDto.Request;
using Application.DTOs.CategoryDto.Responce;
using Application.DTOs.UserDto;
using Application.DTOs.UserDto.Request;
using Application.DTOs.UserDto.Responce;
using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class UserMapProfile : Profile
    {
        public UserMapProfile()
        {
            CreateMap<Order, OrderHistoryDto>();
            CreateMap<User, UserGetAllResponce>()
                .ForMember(dest => dest.orders, opt => opt.MapFrom(Src => Src.OrderHistory));

            CreateMap<User, UserGetByIdResponce>()
                .ForMember(dest => dest.orders, opt => opt.MapFrom(Src => Src.OrderHistory));

            CreateMap<User, UserCreateResponce>();

            CreateMap<User, UserUpdateResponce>();

            CreateMap<UserLoginRequest, User>();

            CreateMap<UserCreateRequest, User>()
                .ConstructUsing(dto => new User
                (
                    Guid.NewGuid(),
                    dto.Email,
                    dto.Password,
                    dto.FullName,
                    dto.Address
                ));

            CreateMap<UserUpdateRequest, User>()
                .ConstructUsing(dto => new User
                (
                    dto.Id,
                    dto.Email,
                    dto.Password,
                    dto.FullName,
                    dto.Address
                ));
        }
    }
}
