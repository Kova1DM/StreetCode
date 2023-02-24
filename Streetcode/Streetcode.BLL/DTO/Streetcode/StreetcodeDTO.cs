using Streetcode.BLL.DTO.AdditionalContent;

namespace Streetcode.BLL.DTO.Streetcode;

public class StreetcodeDTO
{
    public int Id { get; set; }
    public int Index { get; set; }
    public DateTime EventStartOrPersonBirthDate { get; set; }
    public DateTime EventEndOrPersonDeathDate { get; set; }
    public int ViewCount { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public IEnumerable<TagDTO> Tags { get; set; }
    public string Teaser { get; set; }
}