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
    }
}
