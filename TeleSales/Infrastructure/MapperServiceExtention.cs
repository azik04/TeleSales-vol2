using TeleSales.Core.Mapper.Main.CallCenter;

namespace TeleSales.Infrastructure;

public static class MapperServiceExtention
{
    public static void MapperConfiguration(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(CreateCallCenterProfile));
        services.AddAutoMapper(typeof(UpdateCallCenterProfile));
        services.AddAutoMapper(typeof(GetCallCenterProfile));

    }
}
