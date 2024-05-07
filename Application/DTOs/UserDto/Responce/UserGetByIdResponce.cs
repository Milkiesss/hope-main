﻿using Application.DTOs.OrderDto.Responce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.UserDto.Responce
{
    public class UserGetByIdResponce : BaseUserDto
    {
        public Guid Id { get; set; }
        public string passwordHash { get; set; }
        public ICollection<OrderHistoryDto> orders { get; set; }

    }
}
