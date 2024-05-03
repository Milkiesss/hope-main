using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.OrderDto.Request
{
    public class OrderUpdateRequest : BaseOrderDto
    {
        public Guid Id { get; set; }
    }
}
