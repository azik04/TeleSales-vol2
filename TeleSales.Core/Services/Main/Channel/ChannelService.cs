using Microsoft.EntityFrameworkCore;
using Serilog;
using TeleSales.Core.Dto.Main.Channel;
using TeleSales.Core.Interfaces.Main.Channel;
using TeleSales.Core.Response;
using TeleSales.DataProvider.Context;
using TeleSales.DataProvider.Entities.Main;

namespace TeleSales.Core.Services.Main.Channel
{
    public class ChannelService : IChannelService
    {
        private readonly ApplicationDbContext _db;

        public ChannelService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<BaseResponse<GetChannelDto>> Create(CreateChannelDto dto)
        {
            var kanal = new Сhannels()
            {
                Name = dto.Name,
                CreateAt = DateTime.UtcNow,
                Type = dto.Type,
            };

            await _db.Сhannels.AddAsync(kanal);
            await _db.SaveChangesAsync();

            var newKanal = new GetChannelDto()
            {
                id = kanal.id,
                CreateAt = kanal.CreateAt,
                Name = kanal.Name,
                isDeleted = kanal.isDeleted,
                Type = kanal.Type.ToString(),
            };

            // Log message with Kanal ID
            Log.Information("Kanal {KanalId} created successfully", kanal.id);

            return new BaseResponse<GetChannelDto>(newKanal);
        }

        public async Task<BaseResponse<ICollection<GetChannelDto>>> GetAll()
        {
            var kanals = _db.Сhannels.Where(x => !x.isDeleted);

            var kanalDtos = kanals.Select(kanal => new GetChannelDto
            {
                id = kanal.id,
                isDeleted = kanal.isDeleted,
                CreateAt = kanal.CreateAt,
                Name = kanal.Name,
                Type = kanal.Type.ToString(),
            }).ToList();

            // Log message for retrieving all Kanals
            Log.Information("Fetched {KanalCount} kanals", kanalDtos.Count);

            return new BaseResponse<ICollection<GetChannelDto>>(kanalDtos);
        }

        public async Task<BaseResponse<GetChannelDto>> GetById(long id)
        {
            if (id == 0)
                return new BaseResponse<GetChannelDto>(null, false, "Id can't be 0.");

            var kanal = await _db.Сhannels.SingleOrDefaultAsync(x => x.id == id && !x.isDeleted);

            if (kanal == null)
                return new BaseResponse<GetChannelDto>(null, false, "Kanal can't be NULL.");

            var newKanal = new GetChannelDto()
            {
                id = kanal.id,
                CreateAt = kanal.CreateAt,
                Name = kanal.Name,
                isDeleted = kanal.isDeleted,
                Type = kanal.Type.ToString(),
            };

            // Log message with Kanal ID
            Log.Information("Fetched Kanal {KanalId}", kanal.id);

            return new BaseResponse<GetChannelDto>(newKanal);
        }

        public async Task<BaseResponse<GetChannelDto>> Remove(long id)
        {
            if (id == 0)
            {
                Log.Warning("Remove operation failed: Id can't be 0.");
                return new BaseResponse<GetChannelDto>(null, false, "Id can't be 0.");
            }

            var kanal = await _db.Сhannels.SingleOrDefaultAsync(x => x.id == id && !x.isDeleted);

            if (kanal == null)
            {
                Log.Warning("Remove operation failed: Kanal with Id {KanalId} not found.", id);
                return new BaseResponse<GetChannelDto>(null, false, "Kanal can't be NULL.");
            }

            kanal.isDeleted = true;

            _db.Сhannels.Update(kanal);
            await _db.SaveChangesAsync();

            var newKanal = new GetChannelDto()
            {
                id = kanal.id,
                CreateAt = kanal.CreateAt,
                Name = kanal.Name,
                isDeleted = kanal.isDeleted,
                Type = kanal.Type.ToString(),
            };

            // Log message after removal
            Log.Information("Kanal {KanalId} marked as deleted.", kanal.id);

            return new BaseResponse<GetChannelDto>(newKanal);
        }

        public async Task<BaseResponse<GetChannelDto>> Update(long id, UpdateChannelDto dto)
        {
            if (id == 0)
            {
                Log.Warning("Update operation failed: Id can't be 0.");
                return new BaseResponse<GetChannelDto>(null, false, "Id can't be 0.");
            }

            var kanal = await _db.Сhannels.SingleOrDefaultAsync(x => x.id == id && !x.isDeleted);

            if (kanal == null)
            {
                Log.Warning("Update operation failed: Kanal with Id {KanalId} not found.", id);
                return new BaseResponse<GetChannelDto>(null, false, "Kanal can't be NULL.");
            }

            kanal.Name = dto.Name;
            kanal.Type = dto.Type;

            _db.Сhannels.Update(kanal);
            await _db.SaveChangesAsync();

            var newKanal = new GetChannelDto()
            {
                id = kanal.id,
                CreateAt = kanal.CreateAt,
                Name = kanal.Name,
                isDeleted = kanal.isDeleted,
                Type = kanal.Type.ToString(),
            };

            // Log message with updated Kanal ID
            Log.Information("Kanal {KanalId} updated successfully.", kanal.id);

            return new BaseResponse<GetChannelDto>(newKanal);
        }
    }
}
