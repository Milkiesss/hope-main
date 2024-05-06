using Application.DTOs.CategoryDto.Request;
using Application.DTOs.OrderDto.Request;
using Application.DTOs.ProductDto.Request;
using Application.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _sup;
        public OrderController(IOrderService sup)
        {
            _sup = sup;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(OrderCreateRequest request, CancellationToken token)
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
        public async Task<IActionResult> Edit(OrderUpdateRequest request, CancellationToken token)
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
