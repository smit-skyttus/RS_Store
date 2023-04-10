using InfiGrowth.Models.Models;
using InfiGrowth.Services.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InfiGrowth.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await _productService.GetAllProducts());
        }
        [HttpPost]
        public async Task<ProductsResponseModel> CreateProduct(ProductRequestModel product)
        {
            return await _productService.CreateProduct(product);
        }
        [HttpDelete("{productId}")]
        public async Task<ProductsResponseModel> DeleteProduct(int productId)
        {
            return await _productService.DeleteProduct(productId);
        }
        [HttpPut]
        public async Task<ProductsResponseModel> UpdateProduct(ProductsResponseModel product)
        {
            return await _productService.UpdateProduct(product);
        }
        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductById(int productId)
        {
            return Ok (await _productService.GetProductById(productId));
        }
    }
}
