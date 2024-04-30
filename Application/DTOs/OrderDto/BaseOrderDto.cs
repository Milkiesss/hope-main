using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.OrderDto
{
    public class BaseOrderDto
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public ICollection<ItemOrder> items { get; set; }
        public DateTime DateOrder { get; set; }
        public int TotalPrice { get; set; }
    }
}
