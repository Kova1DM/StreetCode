using Streetcode.BLL.DTO.Media.Images;
using Streetcode.BLL.DTO.Streetcode.Update.Interfaces;
using Streetcode.BLL.Enums;

namespace Streetcode.BLL.DTO.Media.Art
{
  public class StreetcodeArtUpdateDTO : StreetcodeArtDTO, IModelState
  {
    public ModelState ModelState { get; set; }
    public bool? IsChanged { get; set; }
  }
}
