using FluentValidation;
using TeleSales.Core.Dto.Rel.Department;

namespace TeleSales.Core.Validation.Rel.Department;

public class CreateDepartmentDtoValidation : AbstractValidator<CreateUpdateDepartmentDto>
{
    public CreateDepartmentDtoValidation()
    {
        RuleFor(x => x.Name)
           .NotEmpty().WithMessage("Şöbə adı tələb olunur.")
           .Length(1, 100).WithMessage("Şöbə adı 1-dən 100 simvola qədər olmalıdır.");

        RuleFor(x => x.AdministrationId)
               .NotNull().WithMessage("Idarə tələb olunur.")
               .GreaterThan(0).WithMessage("İdarə 0-dan böyük olmalıdır.");
    }
   
}
