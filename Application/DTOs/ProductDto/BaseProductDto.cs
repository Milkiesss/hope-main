using Application.DTOs.CategoryDto;
using Application.DTOs.SupplierDto;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.ProductDto
{
    public class BaseProductDto
    {
        public string Name { get; set; } = string.Empty;
        public string UnitOfMeasure { get; set; } = string.Empty;
        public bool Available { get; set; }
        public double Price { get; set; }
        public DateTime ExpiryDate { get; set; }
        public Guid CategoryId { get; set; } = Guid.Empty;
        public Guid SupplierId { get; set; } = Guid.Empty;
    }
}
