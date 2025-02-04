﻿using TeleSales.Core.Dto.Main.CallCenter;
using TeleSales.Core.Response;

namespace TeleSales.Core.Interfaces.Main.CallCenter;

public interface ICallCenterService
{
    //Task<BaseResponse<bool>> ImportFromExcelAsync(Stream excelFileStream, long kanalId);
    Task<byte[]> ExportToExcelAsync(long kanalId);
    Task<BaseResponse<GetCallCenterDto>> Create(CreateCallCenterDto dto);
    Task<BaseResponse<PagedResponse<GetCallCenterDto>>> GetAllByUser(long userId, long kanalId, int pageNumber, int pageSize);
    Task<BaseResponse<PagedResponse<GetCallCenterDto>>> GetAll(long kanalId, int pageNumber, int pageSize);
    Task<BaseResponse<GetCallCenterDto>> GetById(long id);
    Task<BaseResponse<GetCallCenterDto>> Update(long id, UpdateCallCenterDto dto);
    Task<BaseResponse<GetCallCenterDto>> Remove(long id);
}
