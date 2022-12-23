using Streetcode.BLL.DTO.AdditionalContent;
using Streetcode.BLL.DTO.Streetcode;

namespace Streetcode.BLL.DTO.Media;

public class AudioDTO
{
    public int Id;
    public string Description;
    public UrlDTO Url;
    public int StreetcodeId;
    public StreetcodeDTO Streetcode;
}