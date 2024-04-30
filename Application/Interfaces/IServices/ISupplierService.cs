using Application.DTOs.SupplierDto.Request;
using Application.DTOs.SupplierDto.Responce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IServices
{
    public interface ISupplierService
    {
        public Task<SupplierCreateResponce> CreateAsync(SupplierCreateRequest entity, CancellationToken token);
        public Task<SupplierUpdateResponce> UpdateAsync(SupplierUpdateRequest entity, CancellationToken token);
        public Task<bool> DeleteAsync(Guid id, CancellationToken token);
        public Task<SupplierGetByIdResponce> GetByIdAsync(Guid id, CancellationToken token);
        public Task<ICollection<SupplierGetAllResponce>> GetAllAsync(CancellationToken token);
    }
}
