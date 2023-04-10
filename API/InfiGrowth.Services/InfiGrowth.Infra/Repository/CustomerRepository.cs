using InfiGrowth.Entity.Manage;
using InfiGrowth.Infra.Context;
using InfiGrowth.Infra.Repository.Interfaces;
using InfiGrowth.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace InfiGrowth.Infra.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly InfiGrowthContext _context;

        public CustomerRepository(InfiGrowthContext context)
        {
            _context = context;
        }

        public async Task<Customers> CreateCustomer(Customers customer)
        {
            var result = _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customers> DeleteCustomer(int customerId)
        {
            var result = await GetCustomerById(customerId);
              //  _context.Customers.FindAsync(customerId);
            _context.Customers.Remove(result);
            await _context.SaveChangesAsync();
            return result;

        }
                    
        public async Task<List<Customers>> GetAllCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customers> GetCustomerById(int customerId)
        {
            return await _context.Customers.FindAsync(customerId);
        }       

        public async Task<Customers> UpdateCustomer(Customers customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
            return customer;
        }



    }
}
