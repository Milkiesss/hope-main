using Application.DTOs.SupplierDto.Request;
using Application.Interfaces.IServices;

using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _sup;
        public SupplierController(ISupplierService sup)
        {
            _sup = sup;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(SupplierCreateRequest request, CancellationToken token)
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
        public async Task<IActionResult> Edit(SupplierUpdateRequest request, CancellationToken token)
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
