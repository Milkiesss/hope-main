using Application.DTOs.SupplierDto.Responce;
using Application.DTOs.UserDto;
using Application.DTOs.UserDto.Request;
using Application.DTOs.UserDto.Responce;
using Application.Interfaces.IRepository;
using Application.Interfaces.IServices;
using AutoMapper;
using Domain.Models;


namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _rep;
        private readonly ICryptographyService _serv;
        private readonly IMapper _mapper;
        public UserService(IUserRepository rep, ICryptographyService serv, IMapper mapper)
        {
            _rep = rep;
            _serv = serv;
            _mapper = mapper;
        }
        public async Task<UserCreateResponce> CreateAsync(UserCreateRequest entity, CancellationToken token)
        {
            var request = _mapper.Map<User>(entity);
            request.PasswordHash = _serv.HashPassword(entity.Password);
            await _rep.CreateAsync(request, token);
            return _mapper.Map<UserCreateResponce>(request);
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken token)
        {
            return await _rep.DeleteAsync(id, token);
        }

        public async Task<ICollection<UserGetAllResponce>> GetAllAsync(CancellationToken token)
        {
            var result = await _rep.GetAllAsync(token);
            return _mapper.Map<ICollection<UserGetAllResponce>>(result);
        }

        public async Task<UserGetByIdResponce> GetByIdAsync(Guid id, CancellationToken token)
        {
            var result = await _rep.GetByIdAsync(id, token);
            return _mapper.Map<UserGetByIdResponce>(result);
        }

        public async Task<UserUpdateResponce> UpdateAsync(UserUpdateRequest entity, CancellationToken token)
        {
            var request = _mapper.Map<User>(entity);
            request.PasswordHash = _serv.HashPassword(entity.Password);
            await _rep.UpdateAsync(request, token);
            return _mapper.Map<UserUpdateResponce>(request);
        }
        public async Task<Guid> LoginAsync(UserLoginRequest entity, CancellationToken token)
        {
            var request = _mapper.Map<User>(entity);
            var userExist = await _rep.LoginAsync(request, token);
            var passwordVerify = _serv.VerifyPassword(entity.Password, userExist.PasswordHash);
            if(passwordVerify)
                return userExist.Id;
            return Guid.Empty;
        }

    }
}
