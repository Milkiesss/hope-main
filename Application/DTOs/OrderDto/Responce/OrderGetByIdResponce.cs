using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.OrderDto.Responce
{
    public class OrderGetByIdResponce : BaseOrderDto
    {
        public Guid Id { get; set; }
    }
}
