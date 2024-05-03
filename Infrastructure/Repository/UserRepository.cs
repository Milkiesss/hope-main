using Application.Interfaces.IRepository;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken token)
        {
            var result = await _dbcontext.users.FirstOrDefaultAsync(c => c.Id == id, token);
            if (result == null)
                return false;

            _dbcontext.users.Remove(result);
            await _dbcontext.SaveChangesAsync(token);
            return true;
        }

        public async Task<ICollection<User>> GetAllAsync(CancellationToken token)
        {
            return await _dbcontext.users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(Guid id, CancellationToken token)
        {
            var result = await _dbcontext.users.FirstOrDefaultAsync(c => c.Id == id, token);
            if (result == null)
                throw new KeyNotFoundException();
            return result;
        }

        public async Task<User> UpdateAsync(User entity, CancellationToken token)
        {
            _dbcontext.users.Update(entity);
            await _dbcontext.SaveChangesAsync(token);
            return entity;
        }
        
    }
}
