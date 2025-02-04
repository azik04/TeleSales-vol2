﻿using FluentValidation;
using TeleSales.Core.Dto.Main.Kanal;

namespace TeleSales.Core.Validation.Kanal;

public class CreateKanalDtoValidation : AbstractValidator<CreateChannelDto>
{
    public CreateKanalDtoValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Kanal adı tələb olunur.") 
            .Length(1, 100).WithMessage("Kanal adı 1-dən 100 simvola qədər olmalıdır.");
    }
}
