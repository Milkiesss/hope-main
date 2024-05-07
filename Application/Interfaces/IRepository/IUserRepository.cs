using Application.DTOs.UserDto.Request;
using Domain.Models;


namespace Application.Interfaces.IRepository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        public Task<User> LoginAsync(User entity, CancellationToken token);
    }
}
