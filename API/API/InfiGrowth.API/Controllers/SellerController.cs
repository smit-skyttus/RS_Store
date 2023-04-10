using InfiGrowth.Entity.Manage;
using InfiGrowth.Models.Models;
using InfiGrowth.Services.Services;
using InfiGrowth.Services.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InfiGrowth.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly ISellerService _sellerService;

        public SellerController(ISellerService sellerService)
        {
            _sellerService = sellerService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSellers() {
            return Ok(await _sellerService.GetAllSeller());
        }
        [HttpPost]
        public async Task<IActionResult> CreateSeller(SellerRequest seller)
        {
            return Ok(await _sellerService.CreateSeller(seller));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSeller(SellerResponseModel seller)
        {
            return Ok(await _sellerService.UpdateSeller(seller));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteSeller(int id)
        {
            return Ok(await _sellerService.DeleteSeller(id));
        }
        [HttpGet("GetSellerById")]
        public async Task<IActionResult> GetSellerById(int id)
        {
            return Ok(await _sellerService.GetSellerById(id));
        }
    }
}
