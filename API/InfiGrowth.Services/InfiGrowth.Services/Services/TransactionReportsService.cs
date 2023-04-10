using AutoMapper;
using InfiGrowth.Entity.Manage;
using InfiGrowth.Infra.Repository;
using InfiGrowth.Infra.Repository.Interfaces;
using InfiGrowth.Models.Models;
using InfiGrowth.Services.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace InfiGrowth.Services.Services
{
    public class TransactionReportsService : ITransactionReportsService
    {
        private readonly ITransactionReportsRepository _reportsRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public TransactionReportsService(ITransactionReportsRepository reportsRepository, IMapper mapper, IConfiguration configuration)
        {
            _reportsRepository = reportsRepository; 
            _mapper = mapper;
            _configuration = configuration;
        }
        public async Task<TransactionReportsResponseModel> CreateReport(TransactionReportsRequestModel report)
        {
            var result = await _reportsRepository.CreateReport(_mapper.Map<TransactionReports>(report));
            return _mapper.Map<TransactionReportsResponseModel>(result);
        }

        public async Task<TransactionReportsResponseModel> DeleteReport(int reportId)
        {
            var result = await _reportsRepository.DeleteReport(reportId);
            return _mapper.Map<TransactionReportsResponseModel>(result);
        }

        public async Task<List<TransactionReportsResponseModel>> GetAllReports()
        {
            return _mapper.Map <List<TransactionReportsResponseModel>> (await _reportsRepository.GetAllReports());
        }

        public async Task<TransactionReportsResponseModel> GetReportById(int reportId)
        {
            var result = await _reportsRepository.GetReportById(reportId);
            return _mapper.Map<TransactionReportsResponseModel>(result);
        }

        public async Task<TransactionReportsResponseModel> UpdateReport(TransactionReportsResponseModel report)
        {
            var result = await _reportsRepository.UpdateReport(_mapper.Map<TransactionReports>(report));
            return _mapper.Map<TransactionReportsResponseModel>(result);
        }
    }
}
