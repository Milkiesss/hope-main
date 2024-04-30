using Application.DTOs.CategoryDto.Request;
using Application.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _sup;
        public CategoryController(ICategoryService sup)
        {
            _sup = sup;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CategoryCreateRequest request, CancellationToken token)
        {
            var responce = await _sup.CreateAsync(request, token);
            return Ok(responce);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken token)
        {
            var responce = await _sup.DeleteAsync(id, token);
            return Ok(responce);
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(CategoryUpdateRequest request, CancellationToken token)
        {
            var responce = await _sup.UpdateAsync(request, token);
            return Ok();
        }
        [HttpGet("GetList")]
        public async Task<IActionResult> GetLIst(CancellationToken token)
        {
            var responce = await _sup.GetAllAsync(token);
            return Ok(responce);
        }

        [HttpGet("GetDetail")]
        public async Task<IActionResult> Detail(Guid Id, CancellationToken token)
        {
            var responce = await _sup.GetByIdAsync(Id, token);
            return Ok(responce);
        }
    }
}
