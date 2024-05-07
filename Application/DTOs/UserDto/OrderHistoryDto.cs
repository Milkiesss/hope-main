using Application.DTOs.OrderDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.UserDto
{
    public class OrderHistoryDto : BaseOrderDto
    {
        public Guid Id { get; set; }
        public double TotalPrice { get; set; }

    }
}
