using FluentValidation;
using TeleSales.Core.Dto.List.Status;

namespace TeleSales.Core.Validation.List.Status;

public class CreateStatusDtoValidation : AbstractValidator<CreateStatusDto>
{
    public CreateStatusDtoValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Kanal adı tələb olunur.")
            .Length(1, 100).WithMessage("Kanal adı 1-dən 100 simvola qədər olmalıdır.");

    }
}
