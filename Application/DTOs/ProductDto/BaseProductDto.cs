using Application.DTOs.CategoryDto;
using Application.DTOs.SupplierDto;

namespace Application.DTOs.ProductDto
{
    public class BaseProductDto
    {
        public string Name { get; set; }
        public string UnitOfMeasure { get; set; }
        public bool Available { get; set; }
        public double Price { get; set; }
        public DateTime ExpiryDate { get; set; }
        public Guid CategoryId { get; set; }
        public Guid SupplierId { get; set; }
    }
}
