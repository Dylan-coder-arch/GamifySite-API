using GamifySite_API.DTO.TagDefDTO;
using GamifySite_API.Models;

namespace GamifySite_API.Mapper.TagDefMapper
{
    public static class TagDefMapper
    {
        public static TagDefDto ToTagDefDto(this TagDef tagDef)
        {
            return new TagDefDto
            {
                TagColor = tagDef.TagColor,
                TagDefID = tagDef.TagDefID,
                TagName = tagDef.TagName,
            };
        }

        public static TagDef ToTagDefFromCreateDto(this CreateTagDefDto createTagDef)
        {
            return new TagDef
            {
                TagColor = createTagDef.TagColor,
                TagName = createTagDef.TagName,
                TagDefID = Guid.NewGuid(),
            };
        }

    }
}
