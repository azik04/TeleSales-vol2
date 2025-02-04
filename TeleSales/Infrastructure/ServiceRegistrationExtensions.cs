using Microsoft.Extensions.Options;
using TeleSales.Core.Interfaces.Main.Auth;
using TeleSales.Core.Interfaces.Main.Call;
using TeleSales.Core.Interfaces.Main.CallCenter;
using TeleSales.Core.Interfaces.Main.Kanal;
using TeleSales.Core.Interfaces.Main.User;
using TeleSales.Core.Interfaces.Main.UserKanal;
using TeleSales.Core.Services.Main.AUTH;
using TeleSales.Core.Services.Main.Call;
using TeleSales.Core.Services.Main.CallCenter;
using TeleSales.Core.Services.Main.Kanal;
using TeleSales.Core.Services.Main.User;
using TeleSales.Core.Services.Main.UserKanal;
using TeleSales.Mail;
using TRAK.EmailSender;

namespace TeleSales.Infrastructure;

public static class ServiceRegistrationExtensions
{
    public static void AddServiceDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMemoryCache();

        services.Configure<SmptSettings>(configuration.GetSection("SmptSettings"));
        services.AddScoped<SmptSettings>(sp =>
            sp.GetRequiredService<IOptions<SmptSettings>>().Value);

        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ICallCenterService, CallCenterService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IChannelService, ChannelService>();
        services.AddScoped<IDebitorService, CallService>();
        services.AddScoped<IUserChannelService, UserChannelService>();
        services.AddScoped<IEmailService, EmailService>();
    }
}
