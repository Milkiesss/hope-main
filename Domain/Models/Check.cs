using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Check : BaseEntity
    {
        public ICollection<ItemOrder> items { get; set; }
    }
}
