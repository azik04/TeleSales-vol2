using FluentValidation;
using FluentValidation.AspNetCore;
using TeleSales.Core.Validation.Auth;
using TeleSales.Core.Validation.List.ApplicationType;
using TeleSales.Core.Validation.List.City;
using TeleSales.Core.Validation.List.Region;
using TeleSales.Core.Validation.List.Result;
using TeleSales.Core.Validation.List.Status;
using TeleSales.Core.Validation.List.SubStatus;
using TeleSales.Core.Validation.Main.CallCenter;
using TeleSales.Core.Validation.Main.Channel;
using TeleSales.Core.Validation.Main.Debitor;
using TeleSales.Core.Validation.Main.User;
using TeleSales.Core.Validation.Rel.Administration;
using TeleSales.Core.Validation.Rel.Employer;

namespace TeleSales.Infrastructure;

public static class FluentValidationServiceExtention
{
    public static void AddValidationService(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();
        services.AddValidatorsFromAssemblyContaining<AuthDtoValidation>();


        services.AddValidatorsFromAssemblyContaining<CreateApplicationTypeDtoValidation>();
        services.AddValidatorsFromAssemblyContaining<CreateCityDtoValidation>();
        services.AddValidatorsFromAssemblyContaining<CreateRegionDtoValidation>();
        services.AddValidatorsFromAssemblyContaining<CreateResultDtoValidation>();
        services.AddValidatorsFromAssemblyContaining<CreateStatusDtoValidation>();
        services.AddValidatorsFromAssemblyContaining<CreateSubStatusDtoValidation>();

        services.AddValidatorsFromAssemblyContaining<CreateCallCenterDtoValidation>();
        services.AddValidatorsFromAssemblyContaining<UpdateCallCenterDtoValidation>();
        services.AddValidatorsFromAssemblyContaining<CreateChannelDtoValidation>();
        services.AddValidatorsFromAssemblyContaining<UpdateChannelDtoValidation>();
        services.AddValidatorsFromAssemblyContaining<CreateDebitorDtoValidation>();
        services.AddValidatorsFromAssemblyContaining<ExcludeDebitorDtoValidation>();
        services.AddValidatorsFromAssemblyContaining<UpdateDebitorDtoValidation>();
        services.AddValidatorsFromAssemblyContaining<ChangePasswordDtoValidation>();
        services.AddValidatorsFromAssemblyContaining<CreateUserDtoValidation>();
        services.AddValidatorsFromAssemblyContaining<UpdateUserDtoValidation>();

        services.AddValidatorsFromAssemblyContaining<CreateAdministrationDtoValidation>();
        services.AddValidatorsFromAssemblyContaining<CreateDebitorDtoValidation>();
        services.AddValidatorsFromAssemblyContaining<CreateEmployerDtoValidation>();
    }
}
