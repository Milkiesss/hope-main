using Application.DTOs.CategoryDto;
using Application.DTOs.SupplierDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.ProductDto.Responce
{
    public class ProductCreateResponce : BaseProductDto
    {
        public Guid Id { get; set; }
    }
}
