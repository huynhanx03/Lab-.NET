using AutoMapper;
using DataAccess.DTOs;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SilverJewelriesController : ControllerBase
    {
        private readonly ServiceBase<SilverJewelry> _service;
        private readonly ServiceBase<Category> _serviceCategory;
        private readonly IMapper _mapper;

        public SilverJewelriesController(
            ServiceBase<SilverJewelry> service,
            ServiceBase<Category> serviceCategory,
            IMapper mapper)
        {
            _service = service;
            _serviceCategory = serviceCategory;
            _mapper = mapper;
        }

        [Authorize(Roles = "1,4")]
        [HttpGet("search")]
        public async Task<ActionResult<IList<SilverJewelryResponse>>> SearchSilverJewelries(
            string? SilverJewelryName,
            decimal? MetalWeight)
        {
            var entities = await _service.FindAsync<SilverJewelryResponse>(
               expression: _ => (string.IsNullOrEmpty(SilverJewelryName) || _.SilverJewelryName.Contains(SilverJewelryName)) &&
                                (!MetalWeight.HasValue || _.MetalWeight == MetalWeight));
            return Ok(entities);
        }

        [Authorize(Roles = "1")]
        [HttpGet]
        public async Task<ActionResult<IList<SilverJewelryResponse>>> GetSilverJewelries()
        {
            var entities = await _service.FindAsync<SilverJewelryResponse>();
            return Ok(entities);
        }

        [Authorize(Roles = "1")]
        [HttpGet("{id}")]
        public async Task<ActionResult<SilverJewelryResponse>> GetSilverJewelry(string id)
        {
            var entity = await _service.FindByAsync(p => p.SilverJewelryId == id);
            if (entity == null)
            {
                return Problem(detail: $"SilverJewelry id {id} not found", statusCode: 404);
            }
            var entityResponse = _mapper.Map<SilverJewelryResponse>(entity);
            return Ok(entityResponse);
        }

        [Authorize(Roles = "1")]
        [HttpPut]
        public async Task<IActionResult> PutSilverJewelry(SilverJewelryRequest silverJewelryRequest)
        {
            var entity = await _service.FindByAsync(p => p.SilverJewelryId == silverJewelryRequest.SilverJewelryId);
            if (entity == null)
            {
                return Problem(detail: $"SilverJewelry id {silverJewelryRequest.SilverJewelryId} not found", statusCode: 404);
            }

            if (!await _serviceCategory.ExistsByAsync(p => p.CategoryId == silverJewelryRequest.CategoryId))
            {
                return Problem(detail: $"Category id {silverJewelryRequest.CategoryId} not found", statusCode: 404);
            }

            _mapper.Map(silverJewelryRequest, entity);
            await _service.UpdateAsync(entity);
            return NoContent();
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public async Task<ActionResult<SilverJewelryResponse>> PostSilverJewelry(SilverJewelryRequest silverJewelryRequest)
        {
            if (await _service.ExistsByAsync(p => p.SilverJewelryId == silverJewelryRequest.SilverJewelryId))
            {
                return Problem(detail: $"SilverJewelry id {silverJewelryRequest.SilverJewelryId} already exists", statusCode: 400);
            }

            if (!await _serviceCategory.ExistsByAsync(p => p.CategoryId == silverJewelryRequest.CategoryId))
            {
                return Problem(detail: $"Category id {silverJewelryRequest.CategoryId} not found", statusCode: 404);
            }

            var silverJewelry = _mapper.Map<SilverJewelry>(silverJewelryRequest);
            silverJewelry.CreatedDate = DateTime.Now;
            await _service.CreateAsync(silverJewelry);
            return CreatedAtAction(nameof(GetSilverJewelry), new { id = silverJewelry.SilverJewelryId }, _mapper.Map<SilverJewelryResponse>(silverJewelry));
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSilverJewelry(string id)
        {
            var silverJewelry = await _service.FindByAsync(p => p.SilverJewelryId == id);
            if (silverJewelry == null)
            {
                return Problem(detail: $"silverJewelry id {id} not found", statusCode: 404);
            }
            await _service.DeleteAsync(silverJewelry);
            return NoContent();
        }
    }
}
