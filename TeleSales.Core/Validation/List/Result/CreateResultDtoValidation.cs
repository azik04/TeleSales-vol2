using FluentValidation;
using TeleSales.Core.Dto.List.Region;

namespace TeleSales.Core.Validation.List.Result;

public class CreateResultDtoValidation : AbstractValidator<CreateRegionDto>
{
    public CreateResultDtoValidation()
    {
        RuleFor(x => x.Name)
           .NotEmpty().WithMessage("Kanal adı tələb olunur.")
           .Length(1, 100).WithMessage("Kanal adı 1-dən 100 simvola qədər olmalıdır.");
    }
}
