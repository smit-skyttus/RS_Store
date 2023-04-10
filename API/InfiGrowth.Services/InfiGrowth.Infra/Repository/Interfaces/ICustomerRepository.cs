using InfiGrowth.Entity.Manage;
using InfiGrowth.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfiGrowth.Infra.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customers>> GetAllCustomers();
        Task<Customers> CreateCustomer (Customers customer);
        Task<Customers> UpdateCustomer (Customers customer);
        Task<Customers> DeleteCustomer (int customerId);
        Task<Customers> GetCustomerById (int customerId);
    }
}
