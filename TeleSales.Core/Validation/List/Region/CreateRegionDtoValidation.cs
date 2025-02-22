using FluentValidation;
using TeleSales.Core.Dto.List.Region;

namespace TeleSales.Core.Validation.List.Region;

public class CreateRegionDtoValidation : AbstractValidator<CreateRegionDto>
{
    public CreateRegionDtoValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Kanal adı tələb olunur.")
            .Length(1, 100).WithMessage("Kanal adı 1-dən 100 simvola qədər olmalıdır.");

        RuleFor(x => x.CityId)
           .NotNull().WithMessage("ResultId tələb olunur.")
           .GreaterThan(0).WithMessage("ResultId 0-dan böyük olmalıdır.");
    }
}
