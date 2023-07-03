using FluentValidation;
using Streetcode.BLL.DTO.Streetcode.TextContent.Fact;

public class FactDtoValidator : AbstractValidator<FactDto>
{
    public FactDtoValidator()
    {
        RuleFor(dto => dto.ImageId).NotEmpty();
        RuleFor(dto => dto.FactContent).NotEmpty().MaximumLength(600);
    }
}
