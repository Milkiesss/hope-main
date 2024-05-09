using Domain.Validation.Validators;
using Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ItemOrder
    {
        public Guid OrderId { get; set; }
        public virtual Order order { get; set; }
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public ItemOrder() { }
        public ItemOrder(int quantity, Guid productId)
        {
            Quantity = quantity;
            ProductId = productId;
            new ItemOrderValidator(nameof(ItemOrder)).ValidateWithErrors(this);
        }
    }
}
