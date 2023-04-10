using InfiGrowth.Models.Models;
using InfiGrowth.Services.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InfiGrowth.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersService _customersService;

        public CustomersController(ICustomersService customersService) 
        {
            _customersService = customersService;
        }
        [HttpGet]
        public async Task<List<CustomersResponseModel>> GetCustomersList()
        {
            return await _customersService.GetAllCustomers();
        }
        [HttpPost]
        public async Task<CustomersResponseModel> CreateCustomers(CustomersRequestModel customers)
        {
            return await _customersService.CreateCustomers(customers);
        }
        [HttpGet("(CustomerId)")]
        public async Task<CustomersResponseModel> GetCustomerById(int CustomerId)
        {
            return await _customersService.GetCustomersById(CustomerId);        
        }
        [HttpDelete]
        public async Task<CustomersResponseModel> DeleteCustomer(int CustomerId)
        {
            return await _customersService.DeleteCustomers(CustomerId);     
        }
        [HttpPut]
        public async Task<CustomersResponseModel> UpdateCustomer(CustomersResponseModel customers)
        {
            return await _customersService.UpdateCustomers(customers);
        }
    }
}
