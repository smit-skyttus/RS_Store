using InfiGrowth.Entity.Manage;
using InfiGrowth.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfiGrowth.Infra.Repository
{
    public class ShoppingRepository : IShoppingRpository
    {
        private readonly InfiGrowthContext _context;

        public ShoppingRepository(InfiGrowthContext context)
        {
            _context = context;
        }
        public async Task<ShoppingOrder> CreateOrder(ShoppingOrder order)
        {
            _context.ShoppingOrders.Add(order); 
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<ShoppingOrder> DeleteOrder(int orderId)
        {
            var result = await GetOrderById(orderId);
            _context.ShoppingOrders.Remove(result);
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<List<ShoppingOrder>> GetAllOrders()
        {
            return await _context.ShoppingOrders.ToListAsync();
        }

        public async Task<ShoppingOrder> GetOrderById(int orderId)
        {
            return await _context.ShoppingOrders.FirstAsync(x=>x.OrderId==orderId);
        }

        public async Task<ShoppingOrder> UpdateOrder(ShoppingOrder order)
        {
            _context.ShoppingOrders.Update(order);
            await _context.SaveChangesAsync();
            return order;
        }
    }
}
