using Application.DTOs.CategoryDto;
using Application.DTOs.SupplierDto;


namespace Application.DTOs.ProductDto.Responce
{
    public class ProductGetAllResponce : BaseProductDto
    {
        public Guid Id { get; set; }
        public BaseCategoryDto categoryDto { get; set; }
        public BaseSupplierDto supplierDto { get; set; }
    }
}
