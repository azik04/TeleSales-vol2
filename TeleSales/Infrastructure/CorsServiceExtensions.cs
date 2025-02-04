namespace TeleSales.Infrastructure;

public static class CorsServiceExtensions
{
    public static void Cors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowLocalhost",
                builder => builder.WithOrigins("http://localhost:3000", "http://telesales.adra.gov.az", "http://172.16.60.82:3001")
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });
    }
}
