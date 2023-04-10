using AutoMapper;
using InfiGrowth.Infra.Repository.Interfaces;
using InfiGrowth.Models.Models;
using InfiGrowth.Services.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity = InfiGrowth.Entity.Manage;

namespace InfiGrowth.Services.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public CategoriesService(ICategoriesRepository categoriesRepository, IMapper mapper, IConfiguration configuration) 
        {
            _categoriesRepository = categoriesRepository;
            _mapper = mapper;
            _configuration = configuration;
        }
        public async Task<CategoriesResponseModel> CreateCategories(CategoriesRequestModel categories)
        {
            var result = await _categoriesRepository.CreateCategory(_mapper.Map<entity.Categories> (categories));
            return _mapper.Map<CategoriesResponseModel>(result);
        }

        public async Task<CategoriesResponseModel> DeleteCategories(int categoryId)
        {
            var result = await _categoriesRepository.DeleteCategory(categoryId);
            return _mapper.Map<CategoriesResponseModel>(result);
        }

        public async Task<List<CategoriesResponseModel>> GetCategories()
        {
            return _mapper.Map<List<CategoriesResponseModel>>(await _categoriesRepository.GetCategories());
        }

        public async Task<CategoriesResponseModel> GetCategoriesById(int categoryId)
        {
            var result = await _categoriesRepository.GetCategoriesByCategoryId(categoryId);
            return _mapper.Map<CategoriesResponseModel>(result);
        }

        public async Task<CategoriesResponseModel> UpdateCategories(CategoriesResponseModel categories)
        {
            var result = await _categoriesRepository.UpdateCategory(_mapper.Map<entity.Categories> (categories));
            return _mapper.Map<CategoriesResponseModel>(result);
        }
    }
}
