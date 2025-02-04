﻿using FluentValidation;
using FluentValidation.AspNetCore;
using TeleSales.Core.Validation.Auth;
using TeleSales.Core.Validation.Call;
using TeleSales.Core.Validation.CallCenter;
using TeleSales.Core.Validation.User;

namespace TeleSales.Infrastructure;

public static class FluentValidationServiceExtention
{
    public static void AddValidationService(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();
        services.AddValidatorsFromAssemblyContaining<AuthDtoValidation>();

        services.AddValidatorsFromAssemblyContaining<CreateCallDtoValidation>();
        services.AddValidatorsFromAssemblyContaining<UpdateCallDtoValidation>();

        services.AddValidatorsFromAssemblyContaining<UpdateCallDtoValidation>();
        services.AddValidatorsFromAssemblyContaining<ExcludeCallDtoValidation>();

        services.AddValidatorsFromAssemblyContaining<CreateUserDtoValidation>();
        services.AddValidatorsFromAssemblyContaining<UpdateUserDtoValidation>();


        services.AddValidatorsFromAssemblyContaining<CreateCallCenterDtoValidation>();

    }
}
