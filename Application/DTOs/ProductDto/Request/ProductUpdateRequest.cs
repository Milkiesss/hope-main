using Application.DTOs.ProductDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.ProductDto.Request
{
    public class ProductUpdateRequest : BaseProductDto
    {
        public Guid Id { get; set; }
    }
}
