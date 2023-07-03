using FluentValidation;
using Streetcode.BLL.DTO.Media.Audio;

public class AudioFileBaseUpdateDTOValidator : FileBaseDTOValidator<AudioFileBaseUpdateDTO>
{
    public AudioFileBaseUpdateDTOValidator()
    {
        RuleFor(dto => dto.Id).NotEmpty();
    }
}