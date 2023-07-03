using FluentValidation;
using Streetcode.BLL.DTO.Media;

public abstract class FileBaseDTOValidator<T> : AbstractValidator<T>
    where T : FileBaseCreateDTO
{
    protected FileBaseDTOValidator()
    {
        RuleFor(dto => dto.Title).MaximumLength(100);
        RuleFor(dto => dto.BaseFormat).NotEmpty();
        RuleFor(dto => dto.MimeType).NotEmpty().MaximumLength(10);
    }
}