using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class ProductDAO
    {
        public static List<Product> GetProducts() 
        { 
            var ListProducts = new List<Product>();
            try
            {
                using (var context = new PRN231_AS1Context())
                {
                    ListProducts = context.Products.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return ListProducts;
        }

        public static Product FindProductById(int proId)
        {
            Product p = new Product();
            try
            {
                using (var context = new PRN231_AS1Context())
                {
                    p = context.Products.SingleOrDefault(x => x.ProductId == proId);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return p;
        }

        public static void InsertProduct (Product p)
        {
            try
            {
                using (var context = new PRN231_AS1Context())
                {
                    context.Products.Add(p);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void UpdateProduct(Product p)
        {
            try
            {
                using (var context = new PRN231_AS1Context())
                {
                    context.Entry<Product>(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteProduct(Product p)
        {
            try
            {
                using (var context = new PRN231_AS1Context())
                {
                    var p1 = context.Products.SingleOrDefault(c => c.ProductId == p.ProductId);
                    context.Products.Remove(p1);
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
