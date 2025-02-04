using Microsoft.EntityFrameworkCore;
using TeleSales.Core.Response;
using TeleSales.Core.Helpers;
using TeleSales.DataProvider.Context;
using Serilog;
using TeleSales.Core.Interfaces.Main.Auth;
using TeleSales.Core.Dto.Main.AUTH;

namespace TeleSales.Core.Services.Main.AUTH
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _db;
        public AuthService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<BaseResponse<string>> LogIn(AuthDto dto)
        {
            Log.Information("Attempting to log in with email: {Email}", dto.Email);

            var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == dto.Email && !u.isDeleted);

            if (user == null || user.isDeleted)
            {
                Log.Information("Login failed for email: {Email}. User not found or deleted.", dto.Email);
                return new BaseResponse<string>(
                    data: null,
                    success: false,
                    message: "Invalid email or password"
                );
            }

            if (user.Password != dto.Password)
            {
                Log.Information("Login failed for email: {Email}. Incorrect password.", dto.Email);
                return new BaseResponse<string>(
                    data: null,
                    success: false,
                    message: "Invalid email or password"
                );
            }

            var tokenExpiration = dto.RememberMe ? TimeSpan.FromDays(365 * 100) : TimeSpan.FromDays(1);

            var jwtHelper = new GenerateJwtHelper();
            var token = jwtHelper.GenerateJwtToken(user, tokenExpiration);

            Log.Information("Login successful for email: {Email}. Token generated.", dto.Email);

            return new BaseResponse<string>(
                data: token,
                success: true,
                message: "Login successful"
            );
        }
    }
}
