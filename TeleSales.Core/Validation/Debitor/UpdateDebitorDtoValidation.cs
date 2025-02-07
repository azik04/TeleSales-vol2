using FluentValidation;
using TeleSales.Core.Dto.Main.Debitor;

namespace TeleSales.Core.Validation.Debitor;

public class UpdateDebitorDtoValidation : AbstractValidator<UpdateDebitorDto>
{
    public UpdateDebitorDtoValidation()
    {
        RuleFor(x => x.LegalName)
            .NotEmpty().WithMessage("Hüquqi adı tələb olunur.")
            .Length(1, 100).WithMessage("Hüquqi adı 1-dən 100 simvola qədər olmalıdır.");



        RuleFor(x => x.PermissionStartDate)
            .NotEmpty().WithMessage("İcazənin başlanma tarixi tələb olunur.");

     
    }
}

