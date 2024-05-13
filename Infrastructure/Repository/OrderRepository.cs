using Application.Interfaces.IRepository;
using Castle.Core.Smtp;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
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
            await CalculatePrice(entity);
            await _dbcontext.orders.AddAsync(entity, token);
            await _dbcontext.SaveChangesAsync(token);

            _dbcontext.Entry(entity).State = EntityState.Detached;
            return entity;
        }
        private async Task<Order> CalculatePrice(Order entity)
        {
            var items = entity.items.Select(i => i.ProductId).ToList();
            var product =  _dbcontext.products.Where(c => items.Contains(c.Id)).ToList();

            var itemsPrice = entity.items.Select(item => new ItemOrder
            {
                OrderId = entity.Id,
                ProductId = item.ProductId,
                Product = item.Product,
                Quantity = item.Quantity,
                Price = item.Quantity * product.FirstOrDefault(p => p.Id == item.ProductId).Price
            }).ToList();

            entity.items = itemsPrice;
            entity.TotalPrice = itemsPrice.Sum(item => item.Price);
            return entity;
        }
        public async Task<bool> DeleteAsync(Guid id, CancellationToken token)
        {
            var result = await _dbcontext.orders.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id, token);
            if (result == null)
                return false;

            _dbcontext.orders.Remove(result);
            await _dbcontext.SaveChangesAsync(token);
            return true;
        }

        public async Task<ICollection<Order>> GetAllAsync(CancellationToken token)
        {
            return await _dbcontext.orders.AsNoTracking().ToListAsync();
        }

        public async Task<Order> GetByIdAsync(Guid id, CancellationToken token)
        {
            var result = await _dbcontext.orders.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id, token);
            if (result == null)
                throw new KeyNotFoundException();
            return result;
        }
        public async Task<Order> UpdateAsync(Order entity, CancellationToken token)
        {
            await CalculatePrice(entity);
            _dbcontext.orders.Update(entity);
            await _dbcontext.SaveChangesAsync(token);
            _dbcontext.Entry(entity).State = EntityState.Detached;
            return entity;
        }
    }
}
