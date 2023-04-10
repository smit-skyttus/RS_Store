using InfiGrowth.Entity.Manage;
using InfiGrowth.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfiGrowth.Services.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<Products>> GetAllProducts();
        Task<ProductsResponseModel> CreateProduct(ProductRequestModel product);
        Task<ProductsResponseModel> UpdateProduct(ProductsResponseModel product);
        Task<ProductsResponseModel> DeleteProduct(int productId);
        Task<Products> GetProductById(int productId);
    }
}
