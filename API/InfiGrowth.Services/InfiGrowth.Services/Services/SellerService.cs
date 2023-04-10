using AutoMapper;
using InfiGrowth.Entity.Manage;
using InfiGrowth.Infra.Repository;
using InfiGrowth.Infra.Repository.Interfaces;
using InfiGrowth.Models.Models;
using InfiGrowth.Services.Services.Interfaces;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfiGrowth.Services.Services
{
    public class SellerService : ISellerService
    {
        private readonly IMapper _mapper;
        private readonly ISellerRepository _sellerRepository;

        public SellerService(ISellerRepository sellerRepository,IMapper mapper)
        {
            _mapper = mapper;
            _sellerRepository = sellerRepository;
        }
        public async Task<SellerResponseModel> CreateSeller(SellerRequest seller)
        {
            var result = await _sellerRepository.CreateSeller(_mapper.Map<Seller>(seller));
            return _mapper.Map<SellerResponseModel>(result);
        }

        public async Task<SellerResponseModel> DeleteSeller(int sellerId)
        {

            return _mapper.Map<SellerResponseModel>(await _sellerRepository.DeleteSeller(sellerId));
        }

        public async Task<List<SellerResponseModel>> GetAllSeller()
        {
            return _mapper.Map<List<SellerResponseModel>>(await _sellerRepository.GetAllSellers());
        }

        public async Task<SellerResponseModel> GetSellerById(int sellerId)
        {
            return _mapper.Map<SellerResponseModel>( await _sellerRepository.GetSellerById(sellerId));
        }

        public async Task<SellerResponseModel> UpdateSeller(SellerResponseModel seller)
        {
            var result= _sellerRepository.UpdateSeller(_mapper.Map<Seller>(seller));
            return _mapper.Map<SellerResponseModel>(result);
        }
    }
}
