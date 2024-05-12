using Application.DTOs.ProductDto.Request;
using Application.DTOs.ProductDto.Responce;
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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _rep;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository rep, IMapper mapper)
        {
            _rep = rep;
            _mapper = mapper;
        }

        public async Task<ProductCreateResponce> CreateAsync(ProductCreateRequest entity, CancellationToken token)
        {
            var request = _mapper.Map<Product>(entity);
            await _rep.CreateAsync(request, token);
            return _mapper.Map<ProductCreateResponce>(request);
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken token)
        {
            return await _rep.DeleteAsync(id, token);
        }

        public async Task<ICollection<ProductGetAllResponce>> GetAllAsync(CancellationToken token)
        {
            var result = await _rep.GetAllAsync(token);
            return _mapper.Map<ICollection<ProductGetAllResponce>>(result);
        }

        public async Task<ProductGetByIdResponce> GetByIdAsync(Guid id, CancellationToken token)
        {
            var result = await _rep.GetByIdAsync(id, token);
            return _mapper.Map<ProductGetByIdResponce>(result);
        }

        public async Task<ProductUpdateResponce> UpdateAsync(ProductUpdateRequest entity, CancellationToken token)
        {
            var existing = await _rep.GetByIdAsync(entity.Id, token);
            var request = _mapper.Map<Product>(entity);
            await _rep.UpdateAsync(request, token);
            return _mapper.Map<ProductUpdateResponce>(request);
        }
    }
}
