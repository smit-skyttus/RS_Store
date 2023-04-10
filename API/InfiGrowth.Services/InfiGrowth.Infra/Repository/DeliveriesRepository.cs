using InfiGrowth.Entity.Manage;
using InfiGrowth.Infra.Context;
using InfiGrowth.Infra.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfiGrowth.Infra.Repository
{
    public class DeliveriesRepository : IDeliveriesRepository
    {
        private readonly InfiGrowthContext _context;

        public DeliveriesRepository(InfiGrowthContext context) 
        {
            _context = context;
        }
        public async Task<Deliveries> CreateDelivery(Deliveries deliveries)
        {
             _context.Deliveries.Add(deliveries);
            await _context.SaveChangesAsync();
            return deliveries;
        }

        public async Task<Deliveries> DeleteDelivery(int deliveryId)
        {
            var result =  await GetDeliveriesById(deliveryId);
            _context.Deliveries.Remove(result);
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<List<Deliveries>> GetAllDeliveries()
        {
            return await _context.Deliveries.ToListAsync();
        }

        public async Task<Deliveries> GetDeliveriesById(int deliveryId)
        {
            return await _context.Deliveries.FindAsync(deliveryId);
        }

        public async Task<Deliveries> UpdateDelivery(Deliveries deliveries)
        {
            _context.Deliveries.Update(deliveries);
            await _context.SaveChangesAsync();
            return deliveries;  
        }
    }
}
