using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.OrderDto
{
    public class BaseItemOrderDto
    {
        public Guid OrderId { get; set; }
        public Order order { get; set; }
        public Guid ProductId { get; set; }
        public Product product { get; set; }
        public int Quantity { get; set; }
    }
}
