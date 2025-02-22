using FluentValidation;
using TeleSales.Core.Dto.Main.Debitor;

namespace TeleSales.Core.Validation.Main.Debitor;

public class ExcludeDebitorDtoValidation : AbstractValidator<ExcludeDebitorDto>
{
    public ExcludeDebitorDtoValidation()
    {
        RuleFor(x => x.ResultId)
        .Must(id => id > 0)
        .WithMessage("ResultId must be a positive number.");

        RuleFor(x => x.SubResultId)
        .Must(id => id > 0)
        .WithMessage("SubResultId must be a positive number.");


        RuleFor(x => x.Note)
            .MaximumLength(500).WithMessage("Note cannot exceed 500 characters.");

        RuleFor(x => x.LastStatusUpdate)
            .LessThanOrEqualTo(DateTime.Now).WithMessage("LastStatusUpdate must be in the past.");

        RuleFor(x => x.NextCall)
            .NotEmpty().When(x => x.ResultId == 11)
            .WithMessage("NextCall is required.");
    }
}
