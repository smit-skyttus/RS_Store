using AutoMapper;
using InfiGrowth.Entity.Manage;
using InfiGrowth.Infra.Repository.Interfaces;
using InfiGrowth.Models.Models;
using InfiGrowth.Services.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity = InfiGrowth.Entity.Manage;

namespace InfiGrowth.Services.Services
{
    public class DeliveriesService : IDeliveriesService
    {
        private readonly IDeliveriesRepository _deliveriesRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public DeliveriesService(IDeliveriesRepository deliveriesRepository, IMapper mapper, IConfiguration configuration)
        {
            _deliveriesRepository = deliveriesRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<DeliveriesResponseModel> CreateDelivery(DeliveriesRequestModel deliveries)
        {
            var result = await _deliveriesRepository.CreateDelivery(_mapper.Map<entity.Deliveries>(deliveries));
            return _mapper.Map<DeliveriesResponseModel>(result);
        }

        public async Task<DeliveriesResponseModel> DeleteDelivery(int DeliveryId)
        {
            var result = await _deliveriesRepository.DeleteDelivery(DeliveryId);
            return _mapper.Map<DeliveriesResponseModel>(result);
        }

        public async Task<List<DeliveriesResponseModel>> GetAllDeliveries()
        {
            return _mapper.Map<List<DeliveriesResponseModel>>(await _deliveriesRepository.GetAllDeliveries());
        }

        public async Task<DeliveriesResponseModel> GetDeliveriesById(int DeliveryId)
        {
            var result = await _deliveriesRepository.GetDeliveriesById(DeliveryId);
            return _mapper.Map<DeliveriesResponseModel>(result);
        }

        public async Task<DeliveriesResponseModel> UpdateDelivery(DeliveriesResponseModel deliveries)
        {
            var result = await _deliveriesRepository.UpdateDelivery(_mapper.Map<Deliveries>(deliveries));
            return _mapper.Map<DeliveriesResponseModel>(result);
        }
    }
}
 