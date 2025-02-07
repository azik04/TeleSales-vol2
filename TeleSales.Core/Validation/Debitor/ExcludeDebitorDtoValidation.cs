using FluentValidation;
using TeleSales.Core.Dto.Main.Debitor;

namespace TeleSales.Core.Validation.Debitor;

public class ExcludeDebitorDtoValidation : AbstractValidator<ExcludeDebitorDto>
{
    public ExcludeDebitorDtoValidation()
    {
        RuleFor(x => x.ResultId)
                       .IsInEnum().WithMessage("Conclusion must be a valid CallResult.");

        RuleFor(x => x.Note)
            .MaximumLength(500).WithMessage("Note cannot exceed 500 characters.");

        RuleFor(x => x.LastStatusUpdate)
            .LessThanOrEqualTo(DateTime.Now).WithMessage("LastStatusUpdate must be in the past.");

        RuleFor(x => x.NextCall)
            .NotEmpty().When(x => x.ResultId ==5 )
            .WithMessage("NextCall is required when Conclusion is 'YenidənZəng'.");
    }
}
