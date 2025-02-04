using TeleSales.Core.Dto.Main.AUTH;
using TeleSales.Core.Response;

namespace TeleSales.Core.Interfaces.Main.Auth;

public interface IAuthService
{
    Task<BaseResponse<string>> LogIn(AuthDto dto);
}
