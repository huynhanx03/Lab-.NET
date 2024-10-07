using BusinessObject.Models;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoryRepository repository = new CategoryRepository();


        [HttpGet("{id}")]
        public ActionResult<Category> GetCategoryById(int id) => repository.GetCategoryById(id);

        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategories() => repository.GetCategories();

        [HttpPost]
        public IActionResult PostCategory([FromBody] Category c)
        {
            repository.InsertCategory(c);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, [FromBody] Category c)
        {
            var tmp = repository.GetCategoryById(id);
            if (tmp == null)
            {
                return NotFound();
            }
            repository.UpdateCategory(c);
            return NoContent();
        }
    }
}
