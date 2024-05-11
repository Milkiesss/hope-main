using Application.Interfaces.IRepository;
using Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _dbcontext;
        public CategoryRepository(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<Category> CreateAsync(Category entity, CancellationToken token)
        {
            await _dbcontext.categories.AddAsync(entity, token);
            await _dbcontext.SaveChangesAsync(token);
            _dbcontext.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken token)
        {
            var result = await _dbcontext.categories.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id, token);
            if (result == null)
                return false;

            _dbcontext.categories.Remove(result);
            await _dbcontext.SaveChangesAsync(token);
            return true;
        }

        public async Task<ICollection<Category>> GetAllAsync(CancellationToken token)
        {
            return await _dbcontext.categories.AsNoTracking().ToListAsync();
        }

        public async Task<Category> GetByIdAsync(Guid id, CancellationToken token)
        {
            var result = await _dbcontext.categories.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id, token);
            if (result == null)
                throw new KeyNotFoundException();
            return result;
        }

        public async Task<Category> UpdateAsync(Category entity, CancellationToken token)
        {
            _dbcontext.categories.Update(entity);
            await _dbcontext.SaveChangesAsync(token);
            _dbcontext.Entry(entity).State = EntityState.Detached;
            return entity;

        }
    }
}
