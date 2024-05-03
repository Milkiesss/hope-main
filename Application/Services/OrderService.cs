using Application.DTOs.CategoryDto.Responce;
using Application.DTOs.OrderDto.Request;
using Application.DTOs.OrderDto.Responce;
using Application.Interfaces.IRepository;
using Application.Interfaces.IServices;
using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Task<bool> DeleteAsync(Guid id, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<OrderGetAllResponce>> GetAllAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<OrderGetByIdResponce> GetByIdAsync(Guid id, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<OrderUpdateResponce> UpdateAsync(OrderUpdateRequest entity, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
