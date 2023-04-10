using InfiGrowth.Entity.Manage;
using InfiGrowth.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfiGrowth.Services.Services.Interfaces
{
    public interface ISellerService
    {
        Task<List<SellerResponseModel>> GetAllSeller();
        Task<SellerResponseModel> CreateSeller(SellerRequest seller);
        Task<SellerResponseModel> UpdateSeller(SellerResponseModel seller);
        Task<SellerResponseModel> DeleteSeller(int sellerId);
        Task<SellerResponseModel> GetSellerById(int sellerId);
    }
}
