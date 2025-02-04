using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using TeleSales.Core.Dto.Main.CallCenter;
using TeleSales.Core.Interfaces.Main.CallCenter;
using TeleSales.Core.Response;
using TeleSales.DataProvider.Context;
using TeleSales.DataProvider.Entities.Main;

namespace TeleSales.Core.Services.Main.CallCenter;

public class CallCenterService : ICallCenterService
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;
    public CallCenterService(ApplicationDbContext db , IMapper mapper)
    {
        _mapper = mapper;
        _db = db;
    }


    public async Task<BaseResponse<GetCallCenterDto>> Create(CreateCallCenterDto dto)
    {
        var user = await _db.Users.SingleOrDefaultAsync(x => x.id == dto.ExcludedBy);
        if (user == null)
            return new BaseResponse<GetCallCenterDto>("Invalid ExcludedBy user ID.");

        var center = _mapper.Map<CallCenters>(dto);

        await _db.CallCenters.AddAsync(center);
        await _db.SaveChangesAsync();

        var result = _mapper.Map<GetCallCenterDto>(center);

        return new BaseResponse<GetCallCenterDto>(result);
    }




    public async Task<BaseResponse<PagedResponse<GetCallCenterDto>>> GetAllByUser(long userId, long kanalId, int pageNumber, int pageSize)
    {
        if (userId == 0)
            return new BaseResponse<PagedResponse<GetCallCenterDto>>(null, false, "");

        var data = await _db.CallCenters.Where(x => !x.isDeleted && x.ExcludedBy == userId && x.ChannelId == kanalId)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize).ToListAsync();

        var totalCount = await _db.CallCenters.Where(x => !x.isDeleted && x.ExcludedBy == userId).CountAsync();

        var dataDtos = new List<GetCallCenterDto>();
        foreach (var item in data)
        {
            var user = await _db.Users.SingleOrDefaultAsync(x => x.id == item.ExcludedBy);
            var employer = await _db.Employers.SingleOrDefaultAsync(x=> x.id == item.EmployerId);
            var department = await _db.Departments.SingleOrDefaultAsync(x => x.id == item.DepartmentId);
            var administration = _db.Administrations.SingleOrDefaultAsync(x => x.id == item.AdministrationId);
            var region = await _db.Regions.SingleOrDefaultAsync(x => x.id == item.RegionId);
            var application = await _db.ApplicationTypes.SingleOrDefaultAsync(x => x.id == item.ApplicationTypeId);
            dataDtos.Add(new GetCallCenterDto
            {
                DepartmentId = item.DepartmentId,
                DepartmentName = department.Name,
                AdministrationId = administration.Id,
                EmployerName = employer.Name,
                Forwarding = item.Forwarding,
                RegionId = item.RegionId,
                RegionName = region.Name,
                ApplicationTypeId = item.ApplicationTypeId,
                ApplicationTypeName = application.Name,
                AdministrationName = administration.Name,
                DetailsContent = item.DetailsContent,
                Addition = item.Addition,
                Conclusion = item.Conclusion,
                EmployerId = item.EmployerId,
                ExcludedBy = item.ExcludedBy,
                Phone = item.Phone,
                FullName = item.FullName,
                CreateAt = item.CreateAt,
                VOEN = item.VOEN,
                ShortContent = item.ShortContent,
                id = item.id,
                IsDeleted = item.isDeleted,
                ExcludedByName = user?.FullName,
                ChannelId = item.ChannelId,
                
            });
        }
        var pagedResult = new PagedResponse<GetCallCenterDto>
        {
            CurrentPage = pageNumber,
            Items = dataDtos,
            PageSize = pageSize,
            TotalCount = totalCount,
        };
        return new BaseResponse<PagedResponse<GetCallCenterDto>>(pagedResult);
    }


    public async Task<BaseResponse<PagedResponse<GetCallCenterDto>>> GetAll(long kanalId, int pageNumber, int pageSize)
    {
        if (kanalId <= 0)
            return new BaseResponse<PagedResponse<GetCallCenterDto>>(null, false, "");

        var data = await _db.CallCenters.Where(x => x.kanalId == kanalId && !x.isDeleted)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize).ToListAsync();

        var totalCount = await _db.CallCenters.Where(x => kanalId == x.kanalId == !x.isDeleted).CountAsync();


        var dataDtos = new List<GetCallCenterDto>();
        foreach (var item in data)
        {
            var user = await _db.Users.SingleOrDefaultAsync(x => x.id == item.ExcludedBy);
            dataDtos.Add(new GetCallCenterDto
            {
                Department = item.Department.ToString(),
                Region = item.Region.ToString(),
                ApplicationType = item.ApplicationType.ToString(),
                DetailsContent = item.DetailsContent,
                Addition = item.Addition,
                Conclusion = item.Conclusion,
                ForwardTo = item.ForwardTo,
                ExcludedBy = item.ExcludedBy,
                Phone = item.Phone,
                FullName = item.FullName,
                CreateAt = item.CreateAt,
                VOEN = item.VOEN,
                ShortContent = item.ShortContent,
                id = item.id,
                IsDeleted = item.isDeleted,
                ExcludedByName = user?.FullName,
                kanalId = item.kanalId,
            });
        }
        var pagedResult = new PagedResponse<GetCallCenterDto>
        {
            CurrentPage = pageNumber,
            Items = dataDtos,
            PageSize = pageSize,
            TotalCount = totalCount,
        };
        return new BaseResponse<PagedResponse<GetCallCenterDto>>(pagedResult);
    }


    public async Task<BaseResponse<GetCallCenterDto>> GetById(long id)
    {
        if (id <= 0)
            return new BaseResponse<GetCallCenterDto>(null, false, "");

        var data = await _db.CallCenters.SingleOrDefaultAsync(x => x.id == id);

        var user = await _db.Users.SingleOrDefaultAsync(x => x.id == data.ExcludedBy);

        var dataDto = new GetCallCenterDto
        {
            Department = data.Department.ToString(),
            Region = data.Region.ToString(),
            ApplicationType = data.ApplicationType.ToString(),
            DetailsContent = data.DetailsContent,
            Addition = data.Addition,
            Conclusion = data.Conclusion,
            ForwardTo = data.ForwardTo,
            ExcludedBy = data.ExcludedBy,
            Phone = data.Phone,
            FullName = data.FullName,
            CreateAt = data.CreateAt,
            VOEN = data.VOEN,
            ShortContent = data.ShortContent,
            id = data.id,
            IsDeleted = data.isDeleted,
            ExcludedByName = user?.FullName,
            kanalId = data.kanalId,
        };
        return new BaseResponse<GetCallCenterDto>(dataDto, true, "");
    }


    public async Task<BaseResponse<GetCallCenterDto>> Remove(long id)
    {
        var data = await _db.CallCenters.SingleOrDefaultAsync(x => x.id == id);
        data.isDeleted = true;

        _db.CallCenters.Update(data);
        await _db.SaveChangesAsync();

        var dataDto = new GetCallCenterDto
        {
            Department = data.Department?.ToString(),
            Region = data.Region.ToString(),
            ApplicationType = data.ApplicationType.ToString(),
            DetailsContent = data.DetailsContent,
            Addition = data.Addition,
            Conclusion = data.Conclusion,
            ForwardTo = data.ForwardTo,
            ExcludedBy = data.ExcludedBy,
            Phone = data.Phone,
            FullName = data.FullName,
            CreateAt = data.CreateAt,
            VOEN = data.VOEN,
            ShortContent = data.ShortContent,
            id = data.id,
            IsDeleted = data.isDeleted,
            kanalId = data.kanalId,
        };

        return new BaseResponse<GetCallCenterDto>(dataDto, true, "CallCenter updated successfully.");
    }


    public async Task<byte[]> ExportToExcelAsync(long kanalId)
    {
        try
        {
            var thresholdDate = DateTime.Now;

            var calls = await _db.CallCenters.Where(x => x.kanalId == kanalId && !x.isDeleted).ToListAsync();

            if (!calls.Any())
            {
                throw new Exception("No calls found for the specified channel.");
            }

            foreach (var item in calls)
            {
                item.Users = await _db.Users.SingleOrDefaultAsync(x => x.id == item.ExcludedBy);
            }

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Calls");

                var headers = new[]
                {
                "Kanal", "Zəngin vaxtı", "VÖEN", "Region","Ad, Soyad", "Əlagə", "Operator", "Müraciətin növü", "Qısa məzmun",
                "Müraciətin təfərrüatları", "Yönləndirmə(Olub/Olmuyub)","Yönləndirmə(İdarə)","Şöbənin adı","Yönləndirmə(kimə)","Zəngin nəticəsi", "Əlavə qeyd"
            };

                for (int i = 0; i < headers.Length; i++)
                {
                    worksheet.Cells[1, i + 1].Value = headers[i];
                }

                for (int row = 0; row < calls.Count; row++)
                {
                    var call = calls[row];

                    var user = await _db.Users.SingleOrDefaultAsync(x => x.id == call.ExcludedBy);
                    var kanal = await _db.Kanals.SingleOrDefaultAsync(x => x.id == call.kanalId);

                    worksheet.Cells[row + 2, 1].Value = kanal?.Name;
                    worksheet.Cells[row + 2, 2].Value = call.CreateAt.ToString();
                    worksheet.Cells[row + 2, 3].Value = call.VOEN;
                    worksheet.Cells[row + 2, 4].Value = call.Region;
                    worksheet.Cells[row + 2, 5].Value = call.FullName;
                    worksheet.Cells[row + 2, 6].Value = call.Phone;
                    worksheet.Cells[row + 2, 7].Value = user?.FullName;
                    worksheet.Cells[row + 2, 8].Value = call.ApplicationType.ToString();
                    worksheet.Cells[row + 2, 9].Value = call.ShortContent;
                    worksheet.Cells[row + 2, 10].Value = call.DetailsContent;
                    worksheet.Cells[row + 2, 12].Value = call.ForwardTo;
                    worksheet.Cells[row + 2, 13].Value = call.Department.ToString();
                    worksheet.Cells[row + 2, 14].Value = call.Conclusion;
                    worksheet.Cells[row + 2, 15].Value = call.Addition;
                }
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                return package.GetAsByteArray();
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while exporting data: {ex.Message}");
        }
    }


    public async Task<BaseResponse<GetCallCenterDto>> Update(long id, UpdateCallCenterDto dto)
    {
        if (id <= 0)
            return new BaseResponse<GetCallCenterDto>(null, false, "Invalid ID.");

        var data = await _db.CallCenters.SingleOrDefaultAsync(x => x.id == id && !x.isDeleted);

        if (data == null)
            return new BaseResponse<GetCallCenterDto>(null, false, "CallCenter not found.");

        data.FullName = dto.FirstName + " " + dto.LastName;
        data.Phone = dto.Phone;
        data.Region = dto.Region;
        data.Addition = dto.Addition;
        data.VOEN = dto.VOEN;
        data.Conclusion = dto.Conclusion;
        data.ApplicationType = dto.ApplicationType;
        data.ShortContent = dto.ShortContent;
        data.DetailsContent = dto.DetailsContent;
        data.Department = dto.Department;
        data.ForwardTo = dto.ForwardTo;

        var user = await _db.Users.SingleOrDefaultAsync(x => x.id == data.ExcludedBy);

        _db.CallCenters.Update(data);
        await _db.SaveChangesAsync();

        var dataDto = new GetCallCenterDto
        {
            Department = data.Department?.ToString(),
            Region = data.Region.ToString(),
            ApplicationType = data.ApplicationType.ToString(),
            DetailsContent = data.DetailsContent,
            Addition = data.Addition,
            Conclusion = data.Conclusion,
            ForwardTo = data.ForwardTo,
            ExcludedBy = data.ExcludedBy,
            Phone = data.Phone,
            FullName = data.FullName,
            CreateAt = data.CreateAt,
            VOEN = data.VOEN,
            ShortContent = data.ShortContent,
            id = data.id,
            IsDeleted = data.isDeleted,
            ExcludedByName = user?.FullName,
            kanalId = data.kanalId,
        };

        return new BaseResponse<GetCallCenterDto>(dataDto, true, "CallCenter updated successfully.");
    }

}