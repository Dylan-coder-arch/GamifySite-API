using GamifySite_API.DTO.TagDTO;
using GamifySite_API.Interfaces;
using GamifySite_API.Mapper.TagMapper;
using GamifySite_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamifySite_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ITagRepo _tagRepo;
        public TagController(ITagRepo tagRepo) 
        { 
            _tagRepo = tagRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<TagDto>>> GetAll()
        {
            var tagList = await _tagRepo.GetAllAsync();
            var newTagList = tagList.Select(t => t.ToTagDto()).ToList();
            return newTagList;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<TagDto>> GetByID([FromRoute] Guid id)
        {
            var tag = await _tagRepo.GetByIdAsync(id);
            if (tag == null)
            {
                return NotFound();
            }
            return tag.ToTagDto();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            var tagD = await _tagRepo.DeleteTagAsync(id);
            if (tagD == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<TagDto>> Create([FromBody] CreateTagDto createTag)
        {
            var tag = createTag.ToTagFromCreateDto();
            await _tagRepo.AddTagAsync(tag);
            return tag.ToTagDto();
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<TagDto>> Update([FromRoute] Guid id, [FromBody] UpdateTagDto tagDto)
        {
            var tag = new Tag
            {
                TagID = id,
                TagDefID = tagDto.TagDefID,
            };
            var tagUp = await _tagRepo.UpdateTagAsync(id, tag);
            if (tagUp == null)
            {
                return NotFound();
            }
            return tagUp.ToTagDto();
        }

    }
}
