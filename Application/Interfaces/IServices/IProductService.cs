using Application.DTOs.ProductDto.Request;
using Application.DTOs.ProductDto.Responce;

namespace Application.Interfaces.IServices
{
    public interface IProductService
    {
        public Task<ProductCreateResponce> CreateAsync(ProductCreateRequest entity, CancellationToken token);
        public Task<ProductUpdateResponce> UpdateAsync(ProductUpdateRequest entity, CancellationToken token);
        public Task<bool> DeleteAsync(Guid id, CancellationToken token);
        public Task<ProductGetByIdResponce> GetByIdAsync(Guid id, CancellationToken token);
        public Task<ICollection<ProductGetAllResponce>> GetAllAsync(CancellationToken token);
    }
}
