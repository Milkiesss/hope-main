using Application.Interfaces.IRepository;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _dbcontext;
        public ProductRepository(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<Product> CreateAsync(Product entity, CancellationToken token)
        {
            await _dbcontext.products.AddAsync(entity, token);
            await _dbcontext.SaveChangesAsync(token);
            _dbcontext.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken token)
        {
            var result = await _dbcontext.products.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id, token);
            if (result == null)
                return false;

            _dbcontext.products.Remove(result);
            await _dbcontext.SaveChangesAsync(token);
            return true;
        }

        public async Task<ICollection<Product>> GetAllAsync(CancellationToken token)
        {
            return await _dbcontext.products.AsNoTracking().ToListAsync();
        }

        public async Task<Product> GetByIdAsync(Guid id, CancellationToken token)
        {
            var result = await _dbcontext.products.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id, token);
            if (result == null)
                throw new KeyNotFoundException();
            return result;
        }

        public async Task<Product> UpdateAsync(Product entity, CancellationToken token)
        {
            _dbcontext.products.Update(entity);
            await _dbcontext.SaveChangesAsync(token);
            _dbcontext.Entry(entity).State = EntityState.Detached;
            return entity;
        }
    }
}
