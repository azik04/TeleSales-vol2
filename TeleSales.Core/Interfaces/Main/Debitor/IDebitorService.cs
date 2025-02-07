using TeleSales.Core.Dto.Main.Debitor;
using TeleSales.Core.Response;

namespace TeleSales.Core.Interfaces.Main.Debitor;

public interface IDebitorService
{
    Task<BaseResponse<bool>> ImportFromExcelAsync(Stream excelFileStream, long kanalId);
    Task<BaseResponse<byte[]>> ExportToExcelAsync(long kanalId);
    Task<BaseResponse<GetDebitorDto>> Create(CreateDebitorDto dto);
    Task<BaseResponse<PagedResponse<GetDebitorDto>>> GetAllByUser(long userId, long kanalId, int pageNumber, int pageSize);
    Task<BaseResponse<PagedResponse<GetDebitorDto>>> GetAllNotExcluded(long kanalId, int pageNumber, int pageSize);
    Task<BaseResponse<PagedResponse<GetDebitorDto>>> GetAllExcluded(long kanalId, int pageNumber, int pageSize);
    Task<BaseResponse<ICollection<GetDebitorDto>>> GetRandomCallsByVoen(long kanalId);
    Task<BaseResponse<GetDebitorDto>> GetById(long id);
    Task<BaseResponse<GetDebitorDto>> Update(long id, UpdateDebitorDto dto);
    Task<BaseResponse<GetDebitorDto>> Exclude(long id, ExcludeDebitorDto dto);
    Task<BaseResponse<GetDebitorDto>> Remove(long id);
}
