using InfiGrowth.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfiGrowth.Services.Services.Interfaces
{
    public interface IDeliveriesService
    {
        Task<List<DeliveriesResponseModel>> GetAllDeliveries();
        Task<DeliveriesResponseModel> CreateDelivery(DeliveriesRequestModel deliveries);
        Task<DeliveriesResponseModel> UpdateDelivery(DeliveriesResponseModel deliveries);
        Task<DeliveriesResponseModel> DeleteDelivery(int DeliveryId);
        Task<DeliveriesResponseModel> GetDeliveriesById(int DeliveryId);

    }
}
