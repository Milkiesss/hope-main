using Domain.Validation.Validators;
using Domain.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Order : BaseEntity
    {
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<ItemOrder> items { get; set; }
        public DateTime DateOrder { get; set; }
        public double TotalPrice { get; set; }
        public Order() { }
        public Order(Guid userId)
        {
            UserId = userId;
            new OrderValidator(nameof(Order)).ValidateWithErrors(this);
        }
    }
}
