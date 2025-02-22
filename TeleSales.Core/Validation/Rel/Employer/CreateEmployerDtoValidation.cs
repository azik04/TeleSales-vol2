using FluentValidation;
using TeleSales.DataProvider.Entities.Rel;

namespace TeleSales.Core.Validation.Rel.Employer;

public class CreateEmployerDtoValidation : AbstractValidator<Employers>
{
    public CreateEmployerDtoValidation()
    {
        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("FullName is required.");

        RuleFor(x => x.DepartmentId)
            .NotEmpty().WithMessage("Departament is required.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .Length(2, 50).WithMessage("Last Name must be between 2 and 50 characters.");

        RuleFor(x => x.Position)
            .NotEmpty().WithMessage("Administration is required.");
    }
}
