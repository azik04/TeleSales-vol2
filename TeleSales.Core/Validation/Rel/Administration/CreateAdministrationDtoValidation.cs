using FluentValidation;
using TeleSales.Core.Dto.Rel.Administration;

namespace TeleSales.Core.Validation.Rel.Administration;

public class CreateAdministrationDtoValidation : AbstractValidator<CreateAdministrationDto>
{
    public CreateAdministrationDtoValidation()
    {
        RuleFor(x => x.Name)
         .NotEmpty().WithMessage("Name adı tələb olunur.")
         .Length(1, 100).WithMessage("Name adı 1-dən 100 simvola qədər olmalıdır.");
    }
}
