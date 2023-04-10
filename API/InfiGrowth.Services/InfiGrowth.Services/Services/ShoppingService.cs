using AutoMapper;
using InfiGrowth.Entity.Manage;
using InfiGrowth.Infra.Repository;
using InfiGrowth.Infra.Repository.Interfaces;
using InfiGrowth.Models.Models;
using InfiGrowth.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfiGrowth.Services.Services
{
    public class ShoppingService : IShoppingService
    {
        private readonly IMapper _mapper;
        private readonly IShoppingRpository _shoppingRespository;

        public ShoppingService(IShoppingRpository shoppingRpository,IMapper mapper)
        {
            _mapper = mapper;
            _shoppingRespository = shoppingRpository;
        }
        public async Task<ShoppingResponseModel> CreateOrder(ShoppingRequestModel product)
        {
            var result = await _shoppingRespository.CreateOrder(_mapper.Map<ShoppingOrder>(product));
            return _mapper.Map<ShoppingResponseModel>(result);
        }

        public async Task<ShoppingResponseModel> DeleteOrder(int productId)
        {
            var result = await _shoppingRespository.DeleteOrder(productId);
            return _mapper.Map<ShoppingResponseModel>(result);
        }

        public async Task<List<ShoppingResponseModel>> GetAllOrders()
        {
            return _mapper.Map<List<ShoppingResponseModel>>(await _shoppingRespository.GetAllOrders());
        }

        public async Task<ShoppingResponseModel> GetOrderById(int productId)
        {
            return _mapper.Map<ShoppingResponseModel>(await _shoppingRespository.GetOrderById(productId));
        }

        public async Task<ShoppingResponseModel> UpdateOrder(ShoppingResponseModel product)
        {
            var result = await _shoppingRespository.UpdateOrder(_mapper.Map<ShoppingOrder>(product));
            return _mapper.Map<ShoppingResponseModel>(result);
        }
    }
}
