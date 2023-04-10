using InfiGrowth.Entity.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfiGrowth.Infra.Repository.Interfaces
{
    public interface ICategoriesRepository
    {
        Task<List<Categories>> GetCategories();
        Task<Categories> CreateCategory(Categories categories);
        Task<Categories> UpdateCategory(Categories categories);
        Task<Categories> DeleteCategory(int categoryId);
        Task<Categories> GetCategoriesByCategoryId(int categoryId);
    }
}
