using BusinessObject;
using DataAccess.Service;
using DataAccess.Service.Token;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eStoreAP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [Authorize(Roles = UserRoles.User)]
        [HttpGet("categoryList")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _categoryService.GetPagingList();
                return new JsonResult(new ResponeBase<CategoryDto>
                {
                    Status = ResponeStatus.Success,
                    Result = result
                });
            }
            catch(Exception ex)
            {
                return new JsonResult( new ResponeBase<CategoryDto>
                {
                    Status = ResponeStatus.InternalServer,
                    Message = ex.Message
                });
            }
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
        }
    }
}
