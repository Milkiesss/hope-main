using Application.DTOs.CategoryDto.Request;
using Application.DTOs.CategoryDto.Responce;
using Application.Interfaces.IRepository;
using Application.Interfaces.IServices;
using AutoMapper;
using Domain.Models;

namespace Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _rep;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository rep, IMapper map) 
        { 
            _rep = rep;
            _mapper = map;
        }
        public async Task<CategoryCreateResponce> CreateAsync(CategoryCreateRequest entity, CancellationToken token)
        {
            var request = _mapper.Map<Category>(entity);
            await _rep.CreateAsync(request, token);
            return _mapper.Map<CategoryCreateResponce>(request);
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken token)
        {
             return await _rep.DeleteAsync(id, token);
        }

        public async Task<ICollection<CategoryGetAllResponce>> GetAllAsync(CancellationToken token)
        {
            var request = await _rep.GetAllAsync(token);
            return _mapper.Map<ICollection<CategoryGetAllResponce>>(request);
        }

        public async Task<CategoryGetByIdResponce> GetByIdAsync(Guid id, CancellationToken token)
        {
           var request = await _rep.GetByIdAsync(id,token);
           return _mapper.Map<CategoryGetByIdResponce>(request);
        }

        public async Task<CategotyUpdateResponce> UpdateAsync(CategoryUpdateRequest entity, CancellationToken token)
        {
            var request = _mapper.Map<Category>(entity);
            await _rep.UpdateAsync(request, token);
            return _mapper.Map<CategotyUpdateResponce>(request);
        }
    }
}
