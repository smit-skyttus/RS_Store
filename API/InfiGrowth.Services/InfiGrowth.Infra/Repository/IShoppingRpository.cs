using InfiGrowth.Entity.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfiGrowth.Infra.Repository
{
    public interface IShoppingRpository
    {
        Task<List<ShoppingOrder>> GetAllOrders();
        Task<ShoppingOrder> CreateOrder(ShoppingOrder order);
        Task<ShoppingOrder> UpdateOrder(ShoppingOrder order);
        Task<ShoppingOrder> DeleteOrder(int orderId);
        Task<ShoppingOrder> GetOrderById(int orderId);
    }
}
