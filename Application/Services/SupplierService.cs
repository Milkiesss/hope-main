using Application.DTOs.SupplierDto.Request;
using Application.DTOs.SupplierDto.Responce;
using Application.Interfaces.IRepository;
using Application.Interfaces.IServices;
using AutoMapper;
using Domain.Models;


namespace Application.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepositoty _rep;
        private readonly IMapper _mapper;
        public SupplierService(ISupplierRepositoty rep, IMapper mapper)
        {
            _rep = rep;
            _mapper = mapper;
        }

        public async Task<SupplierCreateResponce> CreateAsync(SupplierCreateRequest entity, CancellationToken token)
        {
            var request = _mapper.Map<Supplier>(entity);
            await _rep.CreateAsync(request, token);
            return _mapper.Map<SupplierCreateResponce>(request);
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken token)
        {
            return await _rep.DeleteAsync(id, token);
        }

        public async Task<ICollection<SupplierGetAllResponce>> GetAllAsync(CancellationToken token)
        {
            var result = await _rep.GetAllAsync(token);
            return _mapper.Map<ICollection<SupplierGetAllResponce>>(result);
        }

        public async Task<SupplierGetByIdResponce> GetByIdAsync(Guid id, CancellationToken token)
        {
            var result = await _rep.GetByIdAsync(id, token);
            return _mapper.Map<SupplierGetByIdResponce>(result);
        }

        public async Task<SupplierUpdateResponce> UpdateAsync(SupplierUpdateRequest entity, CancellationToken token)
        {
            var request = _mapper.Map<Supplier>(entity);
            await _rep.UpdateAsync(request, token);
            return _mapper.Map<SupplierUpdateResponce>(request);
        }
    }
}
