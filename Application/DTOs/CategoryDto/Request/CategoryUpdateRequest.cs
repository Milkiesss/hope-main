using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.CategoryDto.Request
{
    public class CategoryUpdateRequest : BaseCategoryDto
    {
        public Guid Id { get; set; }
    }
}
