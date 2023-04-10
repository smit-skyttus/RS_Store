using InfiGrowth.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfiGrowth.Services.Services.Interfaces
{
    public interface ICategoriesService
    {
        Task<List<CategoriesResponseModel>> GetCategories();
        Task<CategoriesResponseModel> CreateCategories(CategoriesRequestModel categories);
        Task<CategoriesResponseModel> UpdateCategories(CategoriesResponseModel categories);
        Task<CategoriesResponseModel> DeleteCategories(int categoryId);
        Task<CategoriesResponseModel> GetCategoriesById(int categoryId);
    }
}
