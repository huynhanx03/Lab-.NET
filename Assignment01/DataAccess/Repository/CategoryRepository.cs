using BusinessObject.Models;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public List<Category> GetCategories() => CategoryDAO.GetCategories();

        public Category GetCategoryById(int id) => CategoryDAO.Instance.FindCategoryById(id);

        public void InsertCategory(Category c) => CategoryDAO.Instance.InsertCategory(c);

        public void UpdateCategory(Category c) => CategoryDAO.Instance.UpdateCategory(c);
    }
}
