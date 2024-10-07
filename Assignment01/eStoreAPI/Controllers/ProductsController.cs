using BusinessObject.Models;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductRepository repository = new ProductRepository();
        private ICategoryRepository c_repository = new CategoryRepository();


        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts() => repository.GetProducts();
        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id) => repository.GetProductByID(id);

        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategories() => c_repository.GetCategories();

        [HttpPost]
        public IActionResult PostProduct([FromBody] Product p)
        {
            repository.AddProduct(p);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var p = repository.GetProductByID(id);
            if (p == null)
            {
                return NotFound();
            }
            repository.DeleteProduct(p);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product p)
        {
            var tmp = repository.GetProductByID(id);
            if (tmp == null)
            {
                return NotFound();
            }
            repository.UpdateProduct(p);
            return NoContent();
        }
    }
}
