using Application.DTOs.OrderDto.Request;
using Application.DTOs.OrderDto.Responce;
using Application.DTOs.ProductDto.Responce;
using Application.Interfaces.IRepository;
using Application.Interfaces.IServices;
using AutoMapper;
using Domain.Models;

namespace Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _rep;
        private readonly IMapper _mapper;
        public OrderService(IOrderRepository rep, IMapper map)
        {
            _rep = rep;
            _mapper = map;
        }
        public async Task<OrderCreateResponce> CreateAsync(OrderCreateRequest entity, CancellationToken token)
        {
            var request = _mapper.Map<Order>(entity);
            await _rep.CreateAsync(request, token);
            return _mapper.Map<OrderCreateResponce>(request);
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken token)
        {
            return await _rep.DeleteAsync(id, token);
        }

        public async Task<ICollection<OrderGetAllResponce>> GetAllAsync(CancellationToken token)
        {
            var result = await _rep.GetAllAsync(token);
            return _mapper.Map<ICollection<OrderGetAllResponce>>(result);
        }

        public async Task<OrderGetByIdResponce> GetByIdAsync(Guid id, CancellationToken token)
        {
            var result = await _rep.GetByIdAsync(id, token);
            return _mapper.Map<OrderGetByIdResponce>(result);
        }

        public async Task<OrderUpdateResponce> UpdateAsync(OrderUpdateRequest entity, CancellationToken token)
        {
            var request = _mapper.Map<Order>(entity);
            await _rep.UpdateAsync(request, token);
            return _mapper.Map<OrderUpdateResponce>(request);
        }
    }
}
