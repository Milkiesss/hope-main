﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.UserDto.Responce
{
    public class UserCreateResponce : BaseUserDto
    {
        public Guid Id { get; set; }
        public string passwordHash { get; set; }
    }
}
