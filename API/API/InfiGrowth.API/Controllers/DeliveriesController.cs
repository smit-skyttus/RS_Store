using Google.Ads.GoogleAds.V10.Common;
using InfiGrowth.Models.Models;
using InfiGrowth.Services.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InfiGrowth.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveriesController : ControllerBase
    {
        private readonly IDeliveriesService _deliveriesService;

        public DeliveriesController(IDeliveriesService deliveriesService) 
        {
            _deliveriesService = deliveriesService;
        }
        [HttpGet]
        public async Task<List<DeliveriesResponseModel>> GetAllDeliveries()
        {
            return await _deliveriesService.GetAllDeliveries();
        }
        [HttpGet("(deliveryId)")]
        public async Task<DeliveriesResponseModel> GetDeliveryById(int deliveryId)
        {
            return await _deliveriesService.GetDeliveriesById(deliveryId);
        }
        [HttpPost]
        public async Task<DeliveriesResponseModel> CreateDelivery(DeliveriesRequestModel deliveries)
        {
            return await _deliveriesService.CreateDelivery(deliveries);
        }
        [HttpDelete]
        public async Task<DeliveriesResponseModel> DeleteDelivery(int deliveryId)
        {
            return await _deliveriesService.DeleteDelivery(deliveryId);
        }
        [HttpPut]
        public async Task<DeliveriesResponseModel> UpdateDelivery(DeliveriesResponseModel deliveries)
        {
            return await _deliveriesService.UpdateDelivery(deliveries);
        }
    }
}
