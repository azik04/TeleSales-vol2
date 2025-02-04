using FluentValidation;
using TeleSales.Core.Dto.Main.Employer;

namespace TeleSales.Core.Validation.Employer;

public class UpdateEmployerDtoValidation : AbstractValidator<UpdateEmployerDto>
{
    public UpdateEmployerDtoValidation()
    {
        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("FullName is required.");

        RuleFor(x => x.Departament)
            .NotEmpty().WithMessage("Departament is required.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .Length(2, 50).WithMessage("Last Name must be between 2 and 50 characters.");

        RuleFor(x => x.Administration)
            .NotEmpty().WithMessage("Administration is required.");
    }
}
