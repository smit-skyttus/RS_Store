using InfiGrowth.Models.Models;
using InfiGrowth.Services.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InfiGrowth.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _categoriesService;

        public CategoriesController(ICategoriesService categoriesService) 
        {
            _categoriesService = categoriesService;
        }
        [HttpGet]
        public async Task<List<CategoriesResponseModel>> GetCategories()
        {
            return await _categoriesService.GetCategories();
        }
        [HttpPost]
        public async Task<CategoriesResponseModel> CreateCategory(CategoriesRequestModel categories)
        {
            return await _categoriesService.CreateCategories(categories);
            
        }
        [HttpGet("(categoryId)")]
        public async Task<CategoriesResponseModel> GetCategoryById(int categoryId)
        {
            return await _categoriesService.GetCategoriesById(categoryId);
        }
        [HttpDelete]
        public async Task<CategoriesResponseModel> DeleteCategory(int categoryId)
        {
            return await _categoriesService.DeleteCategories(categoryId);
        }
        [HttpPut]
        public async Task<CategoriesResponseModel> UpdateCategory(CategoriesResponseModel categories)
        {
            return await _categoriesService.UpdateCategories(categories);
        }
    }
}
