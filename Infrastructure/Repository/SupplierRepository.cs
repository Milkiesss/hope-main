using Application.Interfaces.IRepository;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class SupplierRepository : ISupplierRepositoty
    {
        private readonly DataContext _dbcontext;
        public SupplierRepository(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Supplier> CreateAsync(Supplier entity, CancellationToken token)
        {
            await _dbcontext.suppliers.AddAsync(entity);
            await _dbcontext.SaveChangesAsync(token);
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken token)
        {
            var result =await _dbcontext.suppliers.FirstOrDefaultAsync(s => s.Id == id,token);
            if (result == null)
                return false;

            _dbcontext.suppliers.Remove(result);
            await _dbcontext.SaveChangesAsync(token);
            return true;
        }

        public async Task<ICollection<Supplier>> GetAllAsync(CancellationToken token)
        {
            return await _dbcontext.suppliers.ToListAsync();
        }

        public async Task<Supplier> GetByIdAsync(Guid id, CancellationToken token)
        {
            var result = await _dbcontext.suppliers.FirstOrDefaultAsync(s => s.Id == id, token);
            if (result == null)
                throw new KeyNotFoundException();
            return result;
        }

        public async Task<Supplier> UpdateAsync(Supplier entity, CancellationToken token)
        {
            _dbcontext.suppliers.Update(entity);
            await _dbcontext.SaveChangesAsync(token);
            return entity;
        }
    }
}
