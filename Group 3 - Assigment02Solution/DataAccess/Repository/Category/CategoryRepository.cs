using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CategoryRepository : IRepositoryCategory
    {
        private readonly EStoreAPContext _context;
        public CategoryRepository(EStoreAPContext context)
        {
            _context = context;
        }

        public Task<bool> Add(Category id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(Guid id)
        {
            var category = await _context.Categories.Where(x => x.CategoryId == id).FirstOrDefaultAsync();
            if (category != null)
            {
                _context.Categories.Remove(category);
                return true;
            }
            return false;
        }

        public async Task<Category> GetById(Guid id)
        {
            var category = await _context.Categories.Where(x => x.CategoryId == id).FirstOrDefaultAsync();
            if (category != null)
            {
                return category;
            }
            return null;
        }

        public async Task<IEnumerable<Category>> GetList()
        {
            var category = await _context.Categories.ToListAsync();
            if (category.Count > 0)
            {
                return category;
            }
            return new List<Category>();
        }

        public async Task<bool> Update(Category newValue)
        {
            _context.Categories.Update(newValue);
            bool result = await _context.SaveChangesAsync() > 0;
            return await Task.FromResult(result);
        }
    }
}
