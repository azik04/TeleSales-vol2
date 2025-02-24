using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuestPDF.Helpers;
using System.Data.Entity;
using System.Threading.Channels;
using TeleSales.Core.Dto.Main.Uzadilma;
using TeleSales.Core.Interfaces.Main.Uzadilma;
using TeleSales.Core.Response;
using TeleSales.DataProvider.Context;
using TeleSales.DataProvider.Entities.Main;
using TeleSales.DataProvider.Enums;

namespace TeleSales.Core.Services.Main.Uzadilma;

public class UzadilmaService : IUzadilmaService
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;

    public UzadilmaService(ApplicationDbContext db , IMapper mapper)
    {
        _db = db; 
        _mapper = mapper;
    }

    public async Task<BaseResponse<GetUzadilmaDto>> CreateAsync(CreateUzadilmaDto dto, long channelId)
    {
        //var channel = await _db.Сhannels.FindAsync(channelId);
       
        //if (channel == null || channel.Type != ChannelType.Uzadma)
        //    return new BaseResponse<GetUzadilmaDto>(null, false);

        var data = _mapper.Map<Uzadilmas>(dto);

        await _db.Uzadilmas.AddAsync(data);
        await _db.SaveChangesAsync();

        var newUzadilma = _mapper.Map<GetUzadilmaDto>(data);

        return new BaseResponse<GetUzadilmaDto>(newUzadilma);
    }

    public async Task<BaseResponse<PagedResponse<GetUzadilmaDto>>> GetAllByChannelAndUserAsync(int pageSize, int pageNumber, long channelId, long userId)
    {
        var data = _db.Uzadilmas
                     .Where(x => !x.isDeleted && x.ChannelId == channelId)
                     .Include(x => x.Department)
                     .Include(x => x.Region)
                     .Include(x => x.Сhannel)
                     .Skip((pageNumber - 1) * pageSize)
                     .Take(pageSize)
                     .ToList();

        var totalCount = _db.Uzadilmas
             .Where(x => !x.isDeleted && x.ChannelId == channelId)
             .Count();

        var dataDtos = _mapper.Map<List<GetUzadilmaDto>>(data);

        var pagedResult = new PagedResponse<GetUzadilmaDto>
        {
            CurrentPage = pageNumber,
            Items = dataDtos,
            PageSize = pageSize,
            TotalCount = totalCount,
        };

        return new BaseResponse<PagedResponse<GetUzadilmaDto>>(pagedResult);
    }

    public async Task<BaseResponse<PagedResponse<GetUzadilmaDto>>> GetAllByChannelAsync(int pageSize, int pageNumber, long channelId)
    {
            var data = _db.Uzadilmas
          .Where(x => !x.isDeleted && x.ChannelId == channelId)
          .Include(x => x.Department)
          .Include(x => x.Region)
          .Include(x => x.Сhannel)
          .Skip((pageNumber - 1) * pageSize)
          .Take(pageSize)
          .ToList();

            var totalCount = _db.Uzadilmas
                 .Where(x => !x.isDeleted && x.ChannelId == channelId)
                 .Count();

            var dataDtos = _mapper.Map<List<GetUzadilmaDto>>(data);

            var pagedResult = new PagedResponse<GetUzadilmaDto>
            {
                CurrentPage = pageNumber,
                Items = dataDtos,
                PageSize = pageSize,
                TotalCount = totalCount,
            };

            return new BaseResponse<PagedResponse<GetUzadilmaDto>>(pagedResult);
    }

    public async Task<BaseResponse<GetUzadilmaDto>> GetById(long id)
    {
        var data =  _db.Uzadilmas
            .Include(x => x.Department)
            .Include(x => x.Region)
            .Include(x => x.Сhannel)
            .SingleOrDefault(x => !x.isDeleted && x.id == id);

        var dataDtos = _mapper.Map<GetUzadilmaDto>(data);

        return new BaseResponse<GetUzadilmaDto>(dataDtos);
    }

    public async Task<BaseResponse<GetUzadilmaDto>> RemoveAsync(long id)
    {
        var data =  _db.Uzadilmas.SingleOrDefault(x => !x.isDeleted && x.id == id);
        
        data.isDeleted = true;
        _db.Uzadilmas.Update(data);
        await _db.SaveChangesAsync();

        var dataDtos = _mapper.Map<GetUzadilmaDto>(data);

        return new BaseResponse<GetUzadilmaDto>(dataDtos);
    }

    public async Task<BaseResponse<GetUzadilmaDto>> UpdateAsync(UpdateUzadilmaDto dto, long id)
    {
        var data = await _db.Uzadilmas.SingleOrDefaultAsync(x => !x.isDeleted && x.id == id);

        var map = _mapper.Map<Uzadilmas>(dto);

        data.isDeleted = true;
        _db.Uzadilmas.Update(data);
        await _db.SaveChangesAsync();

        var dataDtos = _mapper.Map<GetUzadilmaDto>(data);

        return new BaseResponse<GetUzadilmaDto>(dataDtos);
    }
}
