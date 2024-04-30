

namespace Application.Interfaces.IRepository
{
    public interface IBaseRepository<T>
    {
        public Task<T> CreateAsync(T entity, CancellationToken token);
        public Task<T> UpdateAsync(T entity, CancellationToken token);
        public Task<bool> DeleteAsync(Guid id, CancellationToken token);
        public Task<T> GetByIdAsync(Guid id, CancellationToken token);
        public Task<ICollection<T>> GetAllAsync(CancellationToken token); 
    }
}
