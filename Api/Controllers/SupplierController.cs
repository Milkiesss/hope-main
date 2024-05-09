using Application.DTOs.SupplierDto.Request;
using Application.Interfaces.IServices;

using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _serv;
        public SupplierController(ISupplierService sup)
        {
            _serv = sup;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(SupplierCreateRequest request, CancellationToken token)
        {
            var responce = await _serv.CreateAsync(request, token);
            return Ok(responce);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken token)
        {
            var responce = await _serv.DeleteAsync(id, token);
            return Ok(responce);
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(SupplierUpdateRequest request, CancellationToken token)
        {
            var responce = await _serv.UpdateAsync(request, token);
            return Ok();
        }
        [HttpGet("GetList")]
        public async Task<IActionResult> GetLIst(CancellationToken token)
        {
            var responce = await _serv.GetAllAsync(token);
            return Ok(responce);
        }

        [HttpGet("GetDetail")]
        public async Task<IActionResult> Detail(Guid Id, CancellationToken token)
        {
            var responce = await _serv.GetByIdAsync(Id, token);
            return Ok(responce);
        }
    }
}
