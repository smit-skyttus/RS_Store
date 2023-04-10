using InfiGrowth.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfiGrowth.Services.Services.Interfaces
{
    public interface IShoppingService
    {
        Task<List<ShoppingResponseModel>> GetAllOrders();
        Task<ShoppingResponseModel> CreateOrder(ShoppingRequestModel order);
        Task<ShoppingResponseModel> UpdateOrder(ShoppingResponseModel order);
        Task<ShoppingResponseModel> DeleteOrder(int orderId);
        Task<ShoppingResponseModel> GetOrderById(int orderId);
    }
}
