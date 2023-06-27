using AutoMapper;
using Streetcode.BLL.DTO.Media.Images;
using Streetcode.DAL.Entities.Media.Images;
using Streetcode.DAL.Entities.Streetcode;

namespace Streetcode.BLL.Mapping.Media.Images;

public class ImageProfile : Profile
{
    public ImageProfile()
    {
        CreateMap<Image, ImageDTO>().ReverseMap();

        CreateMap<ImageFileBaseCreateDTO, Image>();

        CreateMap<ImageFileBaseUpdateDTO, Image>();

        CreateMap<StreetcodeImageUpdateDTO, Image>();

        CreateMap<StreetcodeImageUpdateDTO, StreetcodeImage>()
            .ForMember(sim => sim.ImageId, opt => opt.MapFrom(siu => siu.Id))
            .ForMember(sim => sim.StreetcodeId, opt => opt.MapFrom(siu => siu.StreetcodeId))
            .ForMember(sim => sim.Image, opt => opt.MapFrom(src => null as Image))
            .ForMember(sim => sim.Streetcode, opt => opt.MapFrom(src => null as StreetcodeContent));
	}
}
