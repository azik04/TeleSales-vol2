using Microsoft.Extensions.Options;
using TeleSales.Core.Helpers.Excell.CallCenterExcellHelper;
using TeleSales.Core.Helpers.Excell.DebitorExcellHelper;
using TeleSales.Core.Helpers.Excell.EmployerExcellHelper;
using TeleSales.Core.Interfaces.List.ApplicationType;
using TeleSales.Core.Interfaces.List.City;
using TeleSales.Core.Interfaces.List.Region;
using TeleSales.Core.Interfaces.List.Result;
using TeleSales.Core.Interfaces.List.Status;
using TeleSales.Core.Interfaces.List.SubResult;
using TeleSales.Core.Interfaces.Main.Auth;
using TeleSales.Core.Interfaces.Main.CallCenter;
using TeleSales.Core.Interfaces.Main.Channel;
using TeleSales.Core.Interfaces.Main.Debitor;
using TeleSales.Core.Interfaces.Main.User;
using TeleSales.Core.Interfaces.Main.UserChannel;
using TeleSales.Core.Interfaces.Main.Uzadilma;
using TeleSales.Core.Interfaces.Rel.Administration;
using TeleSales.Core.Interfaces.Rel.Department;
using TeleSales.Core.Interfaces.Rel.Employer;
using TeleSales.Core.Services.List.ApplicationType;
using TeleSales.Core.Services.List.City;
using TeleSales.Core.Services.List.Region;
using TeleSales.Core.Services.List.Result;
using TeleSales.Core.Services.List.Status;
using TeleSales.Core.Services.List.SubResult;
using TeleSales.Core.Services.Main.AUTH;
using TeleSales.Core.Services.Main.CallCenter;
using TeleSales.Core.Services.Main.Channel;
using TeleSales.Core.Services.Main.Debitor;
using TeleSales.Core.Services.Main.User;
using TeleSales.Core.Services.Main.UserChannel;
using TeleSales.Core.Services.Main.Uzadilma;
using TeleSales.Core.Services.Rel.Administration;
using TeleSales.Core.Services.Rel.Department;
using TeleSales.Core.Services.Rel.Employer;
using TeleSales.Mail;

namespace TeleSales.Infrastructure;

public static class ServiceRegistrationExtensions
{
    public static void AddServiceDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMemoryCache();

        services.Configure<SmtpSettings>(configuration.GetSection("SmptSettings"));
        services.AddScoped<SmtpSettings>(sp =>
            sp.GetRequiredService<IOptions<SmtpSettings>>().Value);

        services.AddScoped<IEmailService, EmailService>();

        //List
        services.AddScoped<IApplicationTypeService, ApplicationTypeService>();
        services.AddScoped<IRegionService, RegionService>();
        services.AddScoped<IResultService, ResultService>();
        services.AddScoped<IStatusService, StatusService>();
        services.AddScoped<ICityService, CityService>();
        services.AddScoped<ISubResultService, SubResultService>();

        //Main
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ICallCenterService, CallCenterService>(); 
        services.AddScoped<IChannelService, ChannelService>();
        services.AddScoped<IDebitorService, DebitorService>();
        services.AddScoped<IUserChannelService, UserChannelService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUzadilmaService, UzadilmaService>();

        //Ref
        services.AddScoped<IEmployerService, EmployerService>();
        services.AddScoped<IAdministrationService, AdministrationService>();
        services.AddScoped<IDepartmentService, DepartmentService>();

        //Helpers
        services.AddScoped<CallCenterExportExcellHelper>();
        services.AddScoped<DebitorExportExcellHelper>();
        services.AddScoped<DebitorImportExcellHelper>();
        services.AddScoped<DebitorErrorExcelFile>();
        services.AddScoped<EmpoyerImportExcellHelper>();
    }
}

