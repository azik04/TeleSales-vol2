using FluentValidation;
using TeleSales.Core.Dto.Main.Channel;

namespace TeleSales.Core.Validation.Channel;

public class CreateKanalDtoValidation : AbstractValidator<CreateChannelDto>
{
    public CreateKanalDtoValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Kanal adı tələb olunur.") 
            .Length(1, 100).WithMessage("Kanal adı 1-dən 100 simvola qədər olmalıdır.");
    }
}
