using AutoMapper;
using InfiGrowth.Entity.Manage;
using InfiGrowth.Infra.Repository.Interfaces;
using InfiGrowth.Models.Models;
using InfiGrowth.Services.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfiGrowth.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public ProductService(IProductRepository productRepository, IMapper mapper, IConfiguration configuration)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _configuration = configuration;
        }
        public async Task<ProductsResponseModel> CreateProduct(ProductRequestModel product)
        {
            var result = await _productRepository.CreateProduct(_mapper.Map<Products>(product));
            return _mapper.Map<ProductsResponseModel>(result);
        }

        public async Task<ProductsResponseModel> DeleteProduct(int productId)
        {
            var result = await _productRepository.DeleteProducts(productId);
            return _mapper.Map<ProductsResponseModel>(result);
        }

        public async Task<List<Products>> GetAllProducts()
        {
            return await _productRepository.GetAllProducts();
            //return await _productRepository.GetAllProducts();
        }

        public async Task<Products> GetProductById(int productId)
        {
            return await _productRepository.GetProductById(productId);
        }

        public async Task<ProductsResponseModel> UpdateProduct(ProductsResponseModel product)
        {
            var result = await _productRepository.UpdateProduct( _mapper.Map<Products>(product));
            return _mapper.Map<ProductsResponseModel>(result);
            
        }
    }
}
