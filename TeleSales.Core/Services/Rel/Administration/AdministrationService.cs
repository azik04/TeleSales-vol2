using TeleSales.Core.Dto.Rel.Administration;
using TeleSales.Core.Interfaces.Rel.Administration;
using TeleSales.Core.Response;

namespace TeleSales.Core.Services.Rel.Administration;

public class AdministrationService : IAdministrationService
{
    public Task<BaseResponse<AdministrationDto>> CreateAsync(AdministrationDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<BaseResponse<AdministrationDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}
