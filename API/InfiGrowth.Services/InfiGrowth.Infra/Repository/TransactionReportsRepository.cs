using InfiGrowth.Entity.Manage;
using InfiGrowth.Infra.Context;
using InfiGrowth.Infra.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfiGrowth.Infra.Repository
{
    public class TransactionReportsRepository : ITransactionReportsRepository
    {
        private readonly InfiGrowthContext _context;

        public TransactionReportsRepository(InfiGrowthContext context) 
        {
            _context = context;
        }
        public async Task<TransactionReports> CreateReport(TransactionReports reports)
        {
            var result = _context.TransactionReports.Add(reports);
            await _context.SaveChangesAsync();
            return reports;
   
        }

        public async Task<TransactionReports> DeleteReport(int reportId)
        {
            var result = await GetReportById(reportId);
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<List<TransactionReports>> GetAllReports()
        {
            return await _context.TransactionReports.ToListAsync();
        }

        public async Task<TransactionReports> GetReportById(int reportId)
        {
            return await _context.TransactionReports.FindAsync(reportId);
        }

        public async Task<TransactionReports> UpdateReport(TransactionReports reports)
        {
            _context.TransactionReports.Update(reports);
            await _context.SaveChangesAsync();
            return reports;
        }
    }
}
