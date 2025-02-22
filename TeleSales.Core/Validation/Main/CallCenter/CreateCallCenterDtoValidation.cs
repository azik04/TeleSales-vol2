﻿using FluentValidation;
using TeleSales.Core.Dto.Main.CallCenter;

namespace TeleSales.Core.Validation.Main.CallCenter;

public class CreateCallCenterDtoValidation : AbstractValidator<CreateCallCenterDto>
{
    public CreateCallCenterDtoValidation()
    {
        RuleFor(x => x.ChannelId)
            .NotEmpty().WithMessage("KanalId is required.")
            .GreaterThan(0).WithMessage("KanalId must be greater than 0.");

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First Name is required.")
            .Length(2, 50).WithMessage("First Name must be between 2 and 50 characters.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last Name is required.")
            .Length(2, 50).WithMessage("Last Name must be between 2 and 50 characters.");

        //RuleFor(x => x.RegionId)
        //    .GreaterThan(0).WithMessage("Region seçilməlidir.");

        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage("Phone is required.");

        RuleFor(x => x.VOEN)
            .NotEmpty().WithMessage("VOEN is required.")
            .Must(voen => voen.ToString().All(char.IsDigit)).WithMessage("VOEN must be a valid number.");

        RuleFor(x => x.ApplicationTypeId)
            .GreaterThan(0).WithMessage("Region seçilməlidir.");

        RuleFor(x => x.ShortContent)
            .NotEmpty().WithMessage("Short Content is required.")
            .MaximumLength(300).WithMessage("Short Content must be less than 300 characters.");

        RuleFor(x => x.DetailsContent)
            .NotEmpty().WithMessage("Details Content is required.")
            .MaximumLength(2000).WithMessage("Details Content must be less than 2000 characters.");

        RuleFor(x => x.isForwarding)
            .NotNull().WithMessage("Forwarding must be specified.");

        RuleFor(x => x.DepartmentId)
            .NotNull().WithMessage("Department must be specified.");


        RuleFor(x => x.Conclusion)
            .NotEmpty().WithMessage("Conclusion is required.")
            .MaximumLength(500).WithMessage("Conclusion must be less than 500 characters.");

        RuleFor(x => x.Addition)
            .MaximumLength(500).WithMessage("Addition must be less than 500 characters.");
    }
}
