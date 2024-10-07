using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
        Product GetProductByID(int id);
        void AddProduct(Product p);
        void UpdateProduct(Product p);
        void DeleteProduct(Product p);
    }
}
