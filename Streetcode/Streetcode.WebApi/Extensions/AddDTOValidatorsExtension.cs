using FluentValidation;
using Streetcode.BLL.DTO.Media.Audio;
using Streetcode.BLL.DTO.Partners;
using Streetcode.BLL.DTO.Streetcode.TextContent.Fact;

namespace Streetcode.WebApi.Extensions;

public static class AddDTOValidatorsExtension
{
    public static void AddDTOValidators(this IServiceCollection services)
    {
        services.AddTransient<IValidator<AudioFileBaseCreateDTO>, AudioFileBaseCreateDTOValidator>();
        services.AddTransient<IValidator<AudioFileBaseUpdateDTO>, AudioFileBaseUpdateDTOValidator>();

        services.AddTransient<IValidator<FactDto>, FactDtoValidator>();
        services.AddTransient<IValidator<CreatePartnerDTO>, PartnerDTOValidator>();
    }
}