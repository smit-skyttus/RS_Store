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
    internal class CategoriesRepository : ICategoriesRepository
    {
        private readonly InfiGrowthContext _context;

        public CategoriesRepository(InfiGrowthContext context) 
        {
            _context = context;
        }
        public async Task<Categories> CreateCategory(Categories categories)
        {
            _context.Categories.Add(categories);
            await _context.SaveChangesAsync();
            return categories;
        }

        public async Task<Categories> DeleteCategory(int categoryId)
        {
           var result = await GetCategoriesByCategoryId(categoryId);
            _context.Categories.Remove(result);
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<List<Categories>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Categories> GetCategoriesByCategoryId(int categoryId)
        {
            return await _context.Categories.FindAsync(categoryId);
        }

        public async Task<Categories> UpdateCategory(Categories categories)
        {
            _context.Categories.Update(categories);
            await _context.SaveChangesAsync();
            return categories;
        }
    }
}
