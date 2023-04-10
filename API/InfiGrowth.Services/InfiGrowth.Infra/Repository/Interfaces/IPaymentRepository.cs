using InfiGrowth.Entity.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfiGrowth.Infra.Repository.Interfaces
{
    public interface IPaymentRepository
    {
        Task<List<Payment>> GetAllPayment();
        Task<Payment> GetPaymentById(int id);
        Task<Payment> CreatePayment(Payment payment);
        Task<Payment> UpdatePayment(Payment payment);
        Task<Payment> DeletePayment(int id);

    }
}
