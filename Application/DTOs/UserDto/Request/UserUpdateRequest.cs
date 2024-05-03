using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.UserDto.Request
{
    public class UserUpdateRequest : BaseUserDto
    {
        public Guid Id { get; set; }
    }
}
