using InfiGrowth.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfiGrowth.Services.Services.Interfaces
{
    public interface ITransactionReportsService
    {
        Task<List<TransactionReportsResponseModel>> GetAllReports();
        Task<TransactionReportsResponseModel> CreateReport(TransactionReportsRequestModel report);
        Task<TransactionReportsResponseModel> UpdateReport(TransactionReportsResponseModel report);
        Task<TransactionReportsResponseModel> DeleteReport(int reportId);
        Task<TransactionReportsResponseModel> GetReportById(int reportId);
    }
}
