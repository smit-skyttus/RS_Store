using InfiGrowth.Models.Models;
using InfiGrowth.Services.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InfiGrowth.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService) 
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public async Task<List<PaymentResponseModel>> GetPayments()
        {
            return await _paymentService.GetPayments();
        }
        [HttpGet("{paymentId}")]
        
        public async Task<PaymentResponseModel> GetPaymentById(int paymentId)
        {
            return await _paymentService.GetPaymentsById(paymentId);
        }
        [HttpPost]
        public async Task<PaymentResponseModel> CreatePayment(PaymentRequestModel payment)
        {
            return await _paymentService.CreatePayments(payment);
        }

        [HttpDelete]
        public async Task<PaymentResponseModel> DeletePayment(int paymentId)
        {
            return await _paymentService.DeletePayments(paymentId);
        }
        [HttpPut]
        public async Task<PaymentResponseModel> UpdatePayment(PaymentResponseModel payment)
        {
            return await _paymentService.UpdatePayments(payment);
        }
    }
}
