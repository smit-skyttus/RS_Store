using InfiGrowth.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfiGrowth.Services.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<List<PaymentResponseModel>> GetPayments();
        Task<PaymentResponseModel> CreatePayments(PaymentRequestModel payments);
        Task<PaymentResponseModel> UpdatePayments(PaymentResponseModel payments);
        Task<PaymentResponseModel> DeletePayments(int paymentId);
        Task<PaymentResponseModel> GetPaymentsById(int paymentId);
    }
}
