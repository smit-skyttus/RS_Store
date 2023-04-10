using InfiGrowth.Entity.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfiGrowth.Infra.Repository.Interfaces
{
    public interface ISellerRepository
    {
        Task<List<Seller>> GetAllSellers();
        Task<Seller> CreateSeller(Seller seller);
        Task<Seller> UpdateSeller(Seller seller);
        Task<Seller> DeleteSeller(int sellerId);
        Task<Seller> GetSellerById(int sellerId);
    }
}
