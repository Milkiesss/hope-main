using Application.DTOs.UserDto.Request;
using Application.DTOs.UserDto.Responce;


namespace Application.Interfaces.IServices
{
    public interface IUserService
    {
        public Task<UserCreateResponce> CreateAsync(UserCreateRequest entity, CancellationToken token);
        public Task<UserUpdateResponce> UpdateAsync(UserUpdateRequest entity, CancellationToken token);
        public Task<bool> DeleteAsync(Guid id, CancellationToken token);
        public Task<UserGetByIdResponce> GetByIdAsync(Guid id, CancellationToken token);
        public Task<ICollection<UserGetAllResponce>> GetAllAsync(CancellationToken token);
    }
}
