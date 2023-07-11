using FluentValidation;
using Streetcode.BLL.DTO.Streetcode.Update;

namespace Streetcode.BLL.Validation
{
    public class StreetcodeUpdateDTOValidator : AbstractValidator<StreetcodeUpdateDTO>
    {
        public StreetcodeUpdateDTOValidator()
        {
            RuleFor(dto => dto.Title)
                .NotEmpty()
                .MaximumLength(100)
                .Must(BeValidString);
        }

        private bool BeValidString(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }
    }
}
