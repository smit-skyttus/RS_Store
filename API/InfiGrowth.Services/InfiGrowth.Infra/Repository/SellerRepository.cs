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
    public class SellerRepository : ISellerRepository
    {
        private readonly InfiGrowthContext _context;

        public SellerRepository(InfiGrowthContext context)
        {
            _context=context;
        }
        public async Task<Seller> CreateSeller(Seller seller)
        {
            _context.Sellers.Add(seller);
            await _context.SaveChangesAsync();
            return seller;
        }

        public async Task<Seller> DeleteSeller(int sellerId)
        {
            var result= await GetSellerById(sellerId);
            _context.Sellers.Remove(result);
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<List<Seller>> GetAllSellers()
        {
            return await _context.Sellers.ToListAsync();
        }

        public async Task<Seller> GetSellerById(int sellerId)
        {
            return await _context.Sellers.FirstAsync(x=>x.SellerId==sellerId);
        }

        public async Task<Seller> UpdateSeller(Seller seller)
        {
            _context.Sellers.Update(seller);
            await _context.SaveChangesAsync();
            return seller;
        }
    }
}
