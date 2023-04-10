using InfiGrowth.Models.Models;
using InfiGrowth.Services.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InfiGrowth.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingController : ControllerBase
    {
        private readonly IShoppingService _shoppingService;

        public ShoppingController(IShoppingService shoppingService)
        {
            _shoppingService = shoppingService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            return Ok(await _shoppingService.GetAllOrders());
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(ShoppingRequestModel shop)
        {
            return Ok(await _shoppingService.CreateOrder(shop));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOrder(ShoppingResponseModel shop)
        {
            return Ok(await _shoppingService.UpdateOrder(shop));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            return Ok(await _shoppingService.DeleteOrder(id));
        }
        [HttpGet("GetSellerById")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            return Ok(await _shoppingService.GetOrderById(id));
        }
    }
}
