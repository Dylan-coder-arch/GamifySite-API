using GamifySite_API.DTO.VendorCategory;
using GamifySite_API.Interfaces;
using GamifySite_API.Mapper.VendorCategoryMapper;
using GamifySite_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamifySite_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorCategoriesController : ControllerBase
    {
        private readonly IVendorCategoryRepository _vendCatRepo;
        public VendorCategoriesController(IVendorCategoryRepository vendCatRepo) 
        {
            _vendCatRepo = vendCatRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<VendorCategoryDto>>> GetAll()
        {
            var vendCatAll = await _vendCatRepo.GetAllAsync();
            var vendCatOb = vendCatAll.Select(vc => vc.ToVendorCategoryDTO()).ToList();
            return vendCatOb;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByID([FromRoute] Guid id)
        {
            var vendObj = await _vendCatRepo.GetByID(id);
            if (vendObj == null)
            {
                return NotFound();
            }
            return Ok(vendObj.ToVendorCategoryDTO());
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var vendCatDel = await _vendCatRepo.DeleteAsync(id);
            if (vendCatDel == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateVendorCategoryDto vendCat)
        {
            var vendMain = vendCat.ToVendorCategoryFromCreate();
            await _vendCatRepo.CreateAsync(vendMain);
            return CreatedAtAction(nameof(GetByID), new { id = vendMain.VendorCategoryID}, vendMain.ToVendorCategoryDTO());
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateVendorCategoryDto vendCat)
        {
            var vendNew = new VendorCategory
            {
                Category = vendCat.Category,
                VendorCategoryID = id
            };
            var updated = await _vendCatRepo.UpdateAsync(id, vendNew);
            if (updated == null)
            {
                return NotFound();
            }
            return Ok(updated);
        }
    }
}
