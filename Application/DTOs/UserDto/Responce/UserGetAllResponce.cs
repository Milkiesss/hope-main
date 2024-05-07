using Application.DTOs.OrderDto;
using Application.DTOs.OrderDto.Responce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.UserDto.Responce
{
    public class UserGetAllResponce : BaseUserDto
    {
        public Guid Id { get; set; }
        public string passwordHash { get; set; }
        public ICollection<OrderCreateResponce> orders { get; set; }
    }
}
