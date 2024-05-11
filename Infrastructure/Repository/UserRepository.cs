﻿using Application.DTOs.UserDto.Request;
using Application.Interfaces.IRepository;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dbcontext;
        public UserRepository(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<User> CreateAsync(User entity, CancellationToken token)
        {
            await _dbcontext.users.AddAsync(entity, token);
            await _dbcontext.SaveChangesAsync(token);
            _dbcontext.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken token)
        {
            var result = await _dbcontext.users.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id, token);
            if (result == null)
                return false;

            _dbcontext.users.Remove(result);
            await _dbcontext.SaveChangesAsync(token);
            return true;
        }

        public async Task<ICollection<User>> GetAllAsync(CancellationToken token)
        {
            return await _dbcontext.users.AsNoTracking().ToListAsync();
        }

        public async Task<User> GetByIdAsync(Guid id, CancellationToken token)
        {
            var result = await _dbcontext.users.AsNoTracking(). FirstOrDefaultAsync(c => c.Id == id, token);
            if (result == null)
                throw new KeyNotFoundException();
            return result;
        }

        public async Task<User> UpdateAsync(User entity, CancellationToken token)
        {
            _dbcontext.users.Update(entity);
            await _dbcontext.SaveChangesAsync(token);

            _dbcontext.Entry(entity).State = EntityState.Detached;
            return entity;
        }
        public async Task<User> LoginAsync(User entity, CancellationToken token)
        {
            var UserExist = await _dbcontext.users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == entity.Email);
            if (UserExist is null)
                throw new InvalidOperationException("User with specified email does not exist.");

            return UserExist;
        }
    }
}
