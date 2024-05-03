using Application.DTOs.CategoryDto.Request;
using Application.DTOs.OrderDto.Request;
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
    }
}
