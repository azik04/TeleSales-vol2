using Microsoft.EntityFrameworkCore;
using TeleSales.Core.Response;
using TeleSales.DataProvider.Context;
using Serilog;
using TeleSales.Core.Interfaces.Main.Auth;
using TeleSales.Core.Dto.Main.AUTH;
using TeleSales.Core.Helpers.JWT;

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
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == dto.Email && !u.isDeleted);

            if (user == null || user.isDeleted)
                return new BaseResponse<string>(null, false, "Invalid email or password");

            if (user.Password != dto.Password)
                return new BaseResponse<string>(null, false, "Invalid email or password");

            var tokenExpiration = dto.RememberMe ? TimeSpan.FromDays(365 * 100) : TimeSpan.FromDays(1);

            var jwtHelper = new GenerateJwtHelper();
            var token = jwtHelper.GenerateJwtToken(user, tokenExpiration);

            Log.Information("Login successful for email: {Email}. Token generated.", dto.Email);

            return new BaseResponse<string>(token, true, "Login successful");
        }
    }
}
