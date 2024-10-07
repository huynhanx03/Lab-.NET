using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO instance = null;
        private static readonly object instanceLock = new Object();

        private CategoryDAO() { }

        public static CategoryDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CategoryDAO();
                    }
                }
                return instance;
            }
        }

        public static List<Category> GetCategories()
        {
            var ListCategories = new List<Category>();
            try
            {
                using (var context = new PRN231_AS1Context())
                {
                    ListCategories = context.Categories.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return ListCategories;
        }

        public Category FindCategoryById(int cId)
        {
            Category c = new Category();
            try
            {
                using (var context = new PRN231_AS1Context())
                {
                    c = context.Categories.SingleOrDefault(x => x.CategoryId == cId);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return c;
        }

        public void InsertCategory(Category c)
        {
            try
            {
                using (var context = new PRN231_AS1Context())
                {
                    context.Categories.Add(c);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void UpdateCategory(Category c)
        {
            try
            {
                using (var context = new PRN231_AS1Context())
                {
                    context.Entry<Category>(c).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
