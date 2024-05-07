using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.UserDto
{
    public class BaseUserDto
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
    }
}
