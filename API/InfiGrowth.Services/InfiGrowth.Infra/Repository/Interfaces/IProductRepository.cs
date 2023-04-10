using InfiGrowth.Entity.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfiGrowth.Infra.Repository.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Products>> GetAllProducts();
        Task<Products> CreateProduct(Products customer);
        Task<Products> UpdateProduct(Products customer);
        Task<Products> DeleteProducts(int productId);
        Task<Products> GetProductById(int productId);
    }
}
