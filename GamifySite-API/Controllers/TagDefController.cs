using GamifySite_API.DTO.TagDefDTO;
using GamifySite_API.Interfaces;
using GamifySite_API.Mapper.TagDefMapper;
using GamifySite_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamifySite_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagDefController : ControllerBase
    {
        private readonly ITagDefRepository _tagDefRepo;
        public TagDefController(ITagDefRepository tagDef) 
        {
            _tagDefRepo = tagDef;
        }

        [HttpGet]
        public async Task<ActionResult<List<TagDefDto>>> GetAllAsync()
        {
            var tagDefItems = await _tagDefRepo.GetAllAsync();
            var tagDefDto = tagDefItems.Select(i => i.ToTagDefDto()).ToList();
            return tagDefDto;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<TagDefDto>> GetById([FromRoute] Guid id)
        {
            var tagDefItem = await _tagDefRepo.GetByIdAsync(id);
            if (tagDefItem == null)
            {
                return NotFound();
            }
            return tagDefItem.ToTagDefDto();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<TagDefDto>> DeleteAsync([FromRoute] Guid id)
        {
            var tagDefDel = await _tagDefRepo.DeleteAsync(id);
            if (tagDefDel == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<TagDefDto>> CreateAsync([FromBody] CreateTagDefDto cTagDefDto)
        {
            var tagDef = cTagDefDto.ToTagDefFromCreateDto();
            await _tagDefRepo.CreateTagAsync(tagDef);
            return CreatedAtAction(nameof(GetById), new { id = tagDef.TagDefID }, tagDef.ToTagDefDto());
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<TagDefDto>> Update([FromRoute] Guid id, [FromBody] UpdateTagDefDto tagDefUpdate)
        {
            var tagDef = new TagDef
            {
                TagDefID = id,
                TagColor = tagDefUpdate.TagColor,
                TagName = tagDefUpdate.TagName,
            };
            var updatedTagDef = await _tagDefRepo.UpdateTagAsync(id, tagDef);
            if (updatedTagDef == null)
            {
                return NotFound();
            }
            return updatedTagDef.ToTagDefDto();
        }

    }
}
