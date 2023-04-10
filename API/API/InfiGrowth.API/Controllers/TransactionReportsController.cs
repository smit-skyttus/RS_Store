using InfiGrowth.Models.Models;
using InfiGrowth.Services.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InfiGrowth.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionReportsController : ControllerBase
    {
        private readonly ITransactionReportsService _reportsService;

        public TransactionReportsController(ITransactionReportsService reportsService) 
        {
            _reportsService = reportsService;
        }
        [HttpGet]
        public async Task<List<TransactionReportsResponseModel>> GetTransactionReports()
        {
            return await _reportsService.GetAllReports();
        }
        [HttpGet("{reportId}")]
        public async Task<TransactionReportsResponseModel> GetTransactionReportsById(int reportId)
        {
            return await _reportsService.GetReportById(reportId);
        }
        [HttpPost]
        public async Task<TransactionReportsResponseModel> CreateTransactionReports(TransactionReportsRequestModel reports)
        {
            return await _reportsService.CreateReport(reports);
        }
        [HttpPut]
        public async Task<TransactionReportsResponseModel> UpdateTransactionReports(TransactionReportsResponseModel reports)
        {
            return await(_reportsService.UpdateReport(reports));
        }
        [HttpDelete]
        public async Task<TransactionReportsResponseModel> DeleteTransactionReports(int reportId)
        {
            return await(_reportsService.DeleteReport(reportId));
        }
    }
}
