using FluentValidation;
using TeleSales.Core.Dto.List.City;

namespace TeleSales.Core.Validation.List.City;

public class CreateCityDtoValidation : AbstractValidator<CreateCityDto>
{
    public CreateCityDtoValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Kanal adı tələb olunur.")
            .Length(1, 100).WithMessage("Kanal adı 1-dən 100 simvola qədər olmalıdır.");

    }
}
