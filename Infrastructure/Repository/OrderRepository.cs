using Application.Interfaces.IRepository;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _dbcontext;
        public OrderRepository(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<Order> CreateAsync(Order entity, CancellationToken token)
        {
            await _dbcontext.orders.AddAsync(entity, token);
            await _dbcontext.SaveChangesAsync(token);
            return entity;
        }

        public Task<bool> DeleteAsync(Guid id, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Order>> GetAllAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetByIdAsync(Guid id, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<Order> UpdateAsync(Order entity, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
