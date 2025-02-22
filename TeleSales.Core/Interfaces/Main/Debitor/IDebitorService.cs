using System.Net.Sockets;
using TeleSales.Core.Dto.Main.Debitor;
using TeleSales.Core.Response;

namespace TeleSales.Core.Interfaces.Main.Debitor;

public interface IDebitorService
{
    Task<FileResponse<bool>> ImportFromExcelAsync(Stream excelFileStream, long channelId);
    Task<BaseResponse<byte[]>> ExportToExcelAsync(long channelId);
    Task<BaseResponse<GetDebitorDto>> CreateAsync(CreateDebitorDto dto, long channelId);
    Task<BaseResponse<PagedResponse<GetDebitorDto>>> GetAllByUserAsync(long userId, long channelId, int pageNumber, int pageSize);
    Task<BaseResponse<PagedResponse<GetDebitorDto>>> GetAllNotExcludedAsync(long channelId, int pageNumber, int pageSize);
    Task<BaseResponse<PagedResponse<GetDebitorDto>>> GetAllExcludedAsync(long channelId, int pageNumber, int pageSize);
    Task<BaseResponse<ICollection<GetDebitorDto>>> GetRandomDebitorAsync(long channelId, long userId);
    Task<BaseResponse<GetDebitorDto>> GetByIdAsync(long id);
    Task<BaseResponse<GetDebitorDto>> UpdateAsync(long id, UpdateDebitorDto dto);
    Task<BaseResponse<GetDebitorDto>> ExcludeAsync(long id, ExcludeDebitorDto dto);
    Task<BaseResponse<GetDebitorDto>> RemoveAsync(long id);
    Task<BaseResponse<PagedResponse<GetDebitorDto>>> SearchByUserAsync(long channelId, long userId, SearchDebitorDto dto, int pageNumber, int pageSize);
    Task<BaseResponse<PagedResponse<GetDebitorDto>>> SearchAsync(long channelId, SearchDebitorDto dto, int pageNumber, int pageSize);


}
