using InfiGrowth.Entity.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfiGrowth.Infra.Repository.Interfaces
{
    public interface IDeliveriesRepository
    {
        Task<List<Deliveries>> GetAllDeliveries();
        Task <Deliveries> CreateDelivery(Deliveries deliveries);
        Task<Deliveries> UpdateDelivery(Deliveries deliveries);
        Task<Deliveries> DeleteDelivery(int deliveryId);
        Task<Deliveries> GetDeliveriesById(int deliveryId);
    }
}
