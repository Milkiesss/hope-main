using Application.DTOs.CategoryDto;
using Application.DTOs.ProductDto;
using Application.DTOs.SupplierDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.ProductDto.Responce
{
    public class ProductGetByIdResponce : BaseProductDto
    {
        public Guid Id { get; set; }
        public BaseCategoryDto categoryDto { get; set; }
        public BaseSupplierDto supplierDto { get; set; }
    }
}
