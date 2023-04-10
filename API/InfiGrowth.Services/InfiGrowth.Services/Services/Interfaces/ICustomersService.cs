using InfiGrowth.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfiGrowth.Services.Services.Interfaces
{
    public interface ICustomersService
    {
        Task<List<CustomersResponseModel>> GetAllCustomers();
        Task<CustomersResponseModel> CreateCustomers(CustomersRequestModel customers);
        Task<CustomersResponseModel> UpdateCustomers(CustomersResponseModel customers);
        Task<CustomersResponseModel> DeleteCustomers(int CustomerId);
        Task<CustomersResponseModel> GetCustomersById(int CustomerId);

    }
}
