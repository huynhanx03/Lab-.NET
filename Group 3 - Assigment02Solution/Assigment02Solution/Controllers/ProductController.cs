using BusinessObject;
using BusinessObject.RequestBody;
using BusinessObject.RequestBody.PrdoductRequest;
using DataAccess.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eStoreAP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }
        // GET: api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> Get([FromBody] ProductRequestBody requestBody)
        {
            try
            {
                var result = await _productService.GetPagingList(requestBody);
                return new JsonResult(new ResponeBase<ProductDto>
                {
                    Status = ResponeStatus.Success,
                    Result = result
                });
            }
            catch (Exception ex)
            {
                return new JsonResult(new ResponeBase<ProductDto>
                {
                    Status = ResponeStatus.InternalServer,
                    Message = ex.Message
                });
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("detailProduct")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                var result = await _productService.GetProductById(Guid.Parse(id));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return new JsonResult(new ResponeBase<ProductDto>
                {
                    Status = ResponeStatus.InternalServer,
                    Message = ex.Message
                });
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var result = await _productService.RemoveProduct(id);
                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                return new JsonResult(new ResponeBase<ProductAddDto>
                {
                    Status = ResponeStatus.InternalServer,
                    Message = ex.Message
                });
            }
        }
    }
}
