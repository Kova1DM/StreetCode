using FluentValidation;
using Streetcode.BLL.DTO.Media.Images;

public class ImageFileBaseCreateDTOValidator : FileBaseDTOValidator<ImageFileBaseCreateDTO>
{
    public ImageFileBaseCreateDTOValidator() // ДОПИСАТИ
    {
        RuleFor(dto => dto.BaseFormat)
            .NotEmpty().WithMessage("BaseFormat is required.");

        RuleFor(dto => dto.Extension)
            .NotEmpty().WithMessage("Extension is required.");
    }
}
