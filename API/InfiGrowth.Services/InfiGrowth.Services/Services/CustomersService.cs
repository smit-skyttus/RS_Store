using AutoMapper;
using InfiGrowth.Infra.Repository.Interfaces;
using InfiGrowth.Models.Models;
using InfiGrowth.Services.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    using entity = InfiGrowth.Entity.Manage;

namespace InfiGrowth.Services.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public CustomersService(ICustomerRepository customerRepository, IMapper mapper, IConfiguration configuration)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _configuration = configuration;
        }
        //=> (_customerRepository, _mapper, _configuration) = (customerRepository, mapper, configuration);

        public async Task<CustomersResponseModel> CreateCustomers(CustomersRequestModel customers)
        {
            var result = await _customerRepository.CreateCustomer(_mapper.Map<entity.Customers>(customers));
            return _mapper.Map<CustomersResponseModel>(result);
        }   

        public async Task<CustomersResponseModel> DeleteCustomers(int CustomerId)
        {
            var result = await _customerRepository.DeleteCustomer(CustomerId);
            return _mapper.Map<CustomersResponseModel>(result);
        }

        public async Task<List<CustomersResponseModel>> GetAllCustomers()
        {
            return _mapper.Map<List<CustomersResponseModel>>(await _customerRepository.GetAllCustomers());
        }

        public async Task<CustomersResponseModel> GetCustomersById(int CustomerId)
        {
            var result = await _customerRepository.GetCustomerById(CustomerId);
            return _mapper.Map<CustomersResponseModel>(result);
        }   

        public async Task<CustomersResponseModel> UpdateCustomers(CustomersResponseModel customers)
        {
            var result = await _customerRepository.UpdateCustomer(_mapper.Map<InfiGrowth.Entity.Manage.Customers>(customers));
            return _mapper.Map<CustomersResponseModel>(result);
        }
    }
}
