using Application.DTOs.CategoryDto.Request;
using Application.DTOs.CategoryDto.Responce;
using Application.DTOs.OrderDto.Request;
using Application.DTOs.OrderDto.Responce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IServices
{
    public interface IOrderService
    {
        public Task<OrderCreateResponce> CreateAsync(OrderCreateRequest entity, CancellationToken token);
        public Task<OrderUpdateResponce> UpdateAsync(OrderUpdateRequest entity, CancellationToken token);
        public Task<bool> DeleteAsync(Guid id, CancellationToken token);
        public Task<OrderGetByIdResponce> GetByIdAsync(Guid id, CancellationToken token);
        public Task<ICollection<OrderGetAllResponce>> GetAllAsync(CancellationToken token);

    }
}
