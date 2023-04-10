using InfiGrowth.Entity.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfiGrowth.Infra.Repository.Interfaces
{
    public interface ITransactionReportsRepository
    {
        Task<List<TransactionReports>> GetAllReports();
        Task<TransactionReports> CreateReport(TransactionReports reports);
        Task<TransactionReports> UpdateReport(TransactionReports reports);
        Task<TransactionReports> DeleteReport(int reportId);
        Task<TransactionReports> GetReportById(int reportId);
    }
}
