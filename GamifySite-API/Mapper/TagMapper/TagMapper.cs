using GamifySite_API.DTO.TagDTO;
using GamifySite_API.Models;

namespace GamifySite_API.Mapper.TagMapper
{
    public static class TagMapper
    {

        public static TagDto ToTagDto(this Tag tag)
        {
            return new TagDto
            {
                TagID = tag.TagID,
                TagDefID = tag.TagDefID,
                VoucherID = tag.VoucherID,
            };
        }

        public static Tag ToTagFromCreateDto(this CreateTagDto createTagDto)
        {
            return new Tag
            {
                TagID = Guid.NewGuid(),
                TagDefID = createTagDto.TagDefID,
                VoucherID = createTagDto.VoucherID,
            };

        }

    }
}
