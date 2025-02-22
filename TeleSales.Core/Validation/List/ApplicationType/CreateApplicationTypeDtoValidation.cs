using FluentValidation;
using TeleSales.Core.Dto.List.ApplicationType;

namespace TeleSales.Core.Validation.List.ApplicationType;

public class CreateApplicationTypeDtoValidation : AbstractValidator<CreateApplicationTypeDto>
{
    public CreateApplicationTypeDtoValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Kanal adı tələb olunur.")
            .Length(1, 100).WithMessage("Kanal adı 1-dən 100 simvola qədər olmalıdır.");

    }
}
