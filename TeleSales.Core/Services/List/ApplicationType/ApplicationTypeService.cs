using TeleSales.Core.Dto.List.ApplicationType;
using TeleSales.Core.Interfaces.List.ApplicationType;
using TeleSales.Core.Response;

namespace TeleSales.Core.Services.List.ApplicationType;

public class ApplicationTypeService : IApplicationTypeService
{
    public Task<BaseResponse<ApplicationTypeDto>> CreateAsync(ApplicationTypeDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<BaseResponse<ApplicationTypeDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}
