using FluentValidation;
using Streetcode.BLL.DTO.Partners;

public class PartnerDTOValidator : AbstractValidator<CreatePartnerDTO>
{
    public PartnerDTOValidator()
    {
        RuleFor(dto => dto.Streetcodes).NotEmpty(); // .ForEach(rule => rule.SetValidator(new StreetcodeShortDTOValidator()));
        RuleFor(dto => dto.PartnerSourceLinks).NotEmpty();
            /*.ForEach(rule => rule.SetValidator(new PartnerSourceLinkValidator()));*/
    }
}
