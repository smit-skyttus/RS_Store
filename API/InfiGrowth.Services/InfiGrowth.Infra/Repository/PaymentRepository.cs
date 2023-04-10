using InfiGrowth.Entity.Manage;
using InfiGrowth.Infra.Context;
using InfiGrowth.Infra.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfiGrowth.Infra.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly InfiGrowthContext _context;

        public PaymentRepository(InfiGrowthContext context) 
        {
            _context = context;
        }
        public async Task<Payment> CreatePayment(Payment payment)
        {
            var result =  _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
            return payment;
        }

        public async Task<Payment> DeletePayment(int id)
        {
            var result = await GetPaymentById(id);
            _context.Payments.Remove(result);
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<List<Payment>> GetAllPayment()
        {
            return await _context.Payments.ToListAsync();
        }

        public async Task<Payment> GetPaymentById(int id)
        {
            return await _context.Payments.FindAsync(id);
        }

        public async Task<Payment> UpdatePayment(Payment payment)
        {
            _context.Payments.Update(payment);
            await _context.SaveChangesAsync();
            return payment;
        }
    }
}
