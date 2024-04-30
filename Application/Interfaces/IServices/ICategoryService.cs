using Application.DTOs.CategoryDto.Request;
using Application.DTOs.CategoryDto.Responce;



namespace Application.Interfaces.IServices
{
    public interface ICategoryService
    {
        public Task<CategoryCreateResponce> CreateAsync(CategoryCreateRequest entity, CancellationToken token);
        public Task<CategotyUpdateResponce> UpdateAsync(CategoryUpdateRequest entity, CancellationToken token);
        public Task<bool> DeleteAsync(Guid id, CancellationToken token);
        public Task<CategoryGetByIdResponce> GetByIdAsync(Guid id, CancellationToken token);
        public Task<ICollection<CategoryGetAllResponce>> GetAllAsync(CancellationToken token);
    }
}
