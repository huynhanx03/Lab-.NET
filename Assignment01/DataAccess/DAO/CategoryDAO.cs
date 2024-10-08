﻿using BusinessObject.Models;
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
                using (var context = new FStoreDBContext())
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
                using (var context = new FStoreDBContext())
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
                using (var context = new FStoreDBContext())
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
                using (var context = new FStoreDBContext())
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

        public void DeleteCategory(Category c)
        {
            try
            {
                using (var context = new FStoreDBContext())
                {
                    var c1 = context.Categories.SingleOrDefault(cf => cf.CategoryId == c.CategoryId);
                    context.Categories.Remove(c1);
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
