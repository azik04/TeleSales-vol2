using FluentValidation;
using FluentValidation.AspNetCore;
using TeleSales.Core.Dto.Main.Debitor;
using TeleSales.Core.Validation.Auth;
using TeleSales.Core.Validation.CallCenter;
using TeleSales.Core.Validation.Debitor;
using TeleSales.Core.Validation.User;

namespace TeleSales.Infrastructure;

public static class FluentValidationServiceExtention
{
    public static void AddValidationService(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();
        services.AddValidatorsFromAssemblyContaining<AuthDtoValidation>();

        services.AddValidatorsFromAssemblyContaining<CreateDebitorDtoValidation>();
        services.AddValidatorsFromAssemblyContaining<UpdateDebitorDto>();

        services.AddValidatorsFromAssemblyContaining<UpdateCallCenterDtoValidation>();
        services.AddValidatorsFromAssemblyContaining<ExcludeDebitorDtoValidation>();

        services.AddValidatorsFromAssemblyContaining<CreateUserDtoValidation>();
        services.AddValidatorsFromAssemblyContaining<UpdateUserDtoValidation>();


        services.AddValidatorsFromAssemblyContaining<CreateCallCenterDtoValidation>();

    }
}
