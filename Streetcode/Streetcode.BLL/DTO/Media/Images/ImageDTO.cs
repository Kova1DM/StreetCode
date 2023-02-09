using Streetcode.BLL.DTO.AdditionalContent;
using Streetcode.BLL.DTO.Streetcode;

namespace Streetcode.BLL.DTO.Media.Images;

public class ImageDTO
{
    public int Id { get; set; }
    public string? Alt { get; set; }
    public UrlDTO Url { get; set; }
    public IEnumerable<StreetcodeDTO>? Streetcodes { get; set; }
}