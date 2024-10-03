using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace ProjectManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductRepository repository = new ProductRepository();

        // GET: api/Products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts() => repository.GetProducts();

        // POST: ProductsController/Products
        [HttpPost]
        public IActionResult PostProduct(Product p)
        {
            repository.SaveProduct(p);
            return NoContent();
        }

        // Delete: ProductsController/Delete/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var p = repository.GetProductById(id);
            if (p == null)
                return NotFound();
            repository.DeleteProduct(p);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product p)
        {
            var pTmp = repository.GetProductById(id);
            if (pTmp == null)
                return NotFound();
            repository.UpdateProduct(p);
            return NoContent();
        }

        // GET: api/Products/Categories
        [HttpGet("Categories")]
        public ActionResult<IEnumerable<Category>> GetCategories()
        {
            var categories = repository.GetCategories();  // Fetch categories from repository
            return Ok(categories);
        }
    }
}
