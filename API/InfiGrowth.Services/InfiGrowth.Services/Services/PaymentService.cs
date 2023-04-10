using AutoMapper;
using InfiGrowth.Infra.Repository;
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
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public PaymentService(IPaymentRepository paymentRepository, IMapper mapper, IConfiguration configuration)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
            _configuration = configuration;
        }
        public async Task<PaymentResponseModel> CreatePayments(PaymentRequestModel payments)
        {
            var result = await _paymentRepository.CreatePayment(_mapper.Map<entity.Payment>(payments));
            return _mapper.Map<PaymentResponseModel>(result);
        }

        public async Task<PaymentResponseModel> DeletePayments(int paymentId)
        {
            var result = await _paymentRepository.DeletePayment(paymentId);
            return _mapper.Map<PaymentResponseModel>(result);

        }

        public async Task<List<PaymentResponseModel>> GetPayments()
        {
            return _mapper.Map<List<PaymentResponseModel>>(await _paymentRepository.GetAllPayment());
        }

        public async Task<PaymentResponseModel> GetPaymentsById(int paymentId)
        {
            var result = await _paymentRepository.GetPaymentById(paymentId);
            return _mapper.Map<PaymentResponseModel>(result);
        }

        public async Task<PaymentResponseModel> UpdatePayments(PaymentResponseModel payments)
        {
            var result = await _paymentRepository.UpdatePayment(_mapper.Map<entity.Payment>(payments));
            return _mapper.Map<PaymentResponseModel>(result);
        }
    }
}
