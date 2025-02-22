using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using TeleSales.Core.Mapper.Main.CallCenter;
using TeleSales.Core.Mapper.Main.Debitor;
using TeleSales.Core.Mapper.Main.User;
using TeleSales.Core.Mapper.Main.Uzadilma;

namespace TeleSales.Infrastructure
{
    public static class MapperServiceExtention
    {
        public static void AddMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<CreateCallCenterProfile>();
                cfg.AddProfile<UpdateCallCenterProfile>();
                cfg.AddProfile<GetCallCenterProfile>();

                cfg.AddProfile<CreateDebitorProfile>();
                cfg.AddProfile<GetDebitorProfile>();
                cfg.AddProfile<UpdateDebitorProfile>();

                cfg.AddProfile<CreateUserProfile>();
                cfg.AddProfile<GetUserProfile>();
                cfg.AddProfile<UpdateUserProfile>();

                cfg.AddProfile<CreateUzadilmaProfile>();
                cfg.AddProfile<GetUzadilmaProfile>();
                cfg.AddProfile<UpdateUzadilmaProfile>();
            });
        }
    }
}
