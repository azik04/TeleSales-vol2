using Microsoft.EntityFrameworkCore;
using Serilog;
using TeleSales.Core.Dto.Main.Channel;
using TeleSales.Core.Dto.Main.User;
using TeleSales.Core.Dto.Main.UserChannel;
using TeleSales.Core.Interfaces.Main.UserChannel;
using TeleSales.Core.Response;
using TeleSales.DataProvider.Context;
using TeleSales.DataProvider.Entities.Main;

namespace TeleSales.Core.Services.Main.UserChannel;

public class UserChannelService : IUserChannelService
{
    private readonly ApplicationDbContext _db;

    public UserChannelService(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<BaseResponse<GetUserChannelDto>> AddToChanelAsync(CreateUserChannelDto dto)
    {
        var kanal = await _db.Сhannels.SingleOrDefaultAsync(x => x.id == dto.ChannelId);
        var user = await _db.Users.SingleOrDefaultAsync(x => x.id == dto.UserId);

        if (user == null || kanal == null)
        {
            Log.Information("User or Kanal not found. UserId: {UserId}, KanalId: {KanalId}", dto.UserId, dto.ChannelId);
            return new BaseResponse<GetUserChannelDto>(null, false, "User or Kanal not found.");
        }

        var existingUser = await _db.UserChannels
            .SingleOrDefaultAsync(x => x.СhannelId == dto.ChannelId && x.UserId == dto.UserId);

        if (existingUser != null)
        {
            if (existingUser.isDeleted)
            {
                existingUser.isDeleted = false;
                existingUser.CreateAt = DateTime.Now;

                await _db.SaveChangesAsync();

                var restoredDto = new GetUserChannelDto
                {
                    ChannelId = existingUser.СhannelId,
                    UserId = existingUser.UserId,
                    UserEmail = user.Email,
                    ChannelName = kanal.Name,
                };

                Log.Information("User successfully re-added to the channel. UserId: {UserId}, KanalId: {KanalId}", dto.UserId, dto.ChannelId);
                return new BaseResponse<GetUserChannelDto>(restoredDto, true, "User successfully re-added to the channel.");
            }

            Log.Information("User is already assigned to this channel. UserId: {UserId}, KanalId: {KanalId}", dto.UserId, dto.ChannelId);
            return new BaseResponse<GetUserChannelDto>(null, true, "User is already assigned to this channel.");
        }

        var userKanal = new UserChannels
        {
            СhannelId = dto.ChannelId,
            UserId = dto.UserId,
            CreateAt = DateTime.Now
        };

        await _db.UserChannels.AddAsync(userKanal);
        await _db.SaveChangesAsync();

        var newDto = new GetUserChannelDto
        {
            ChannelId = userKanal.СhannelId,
            UserId = userKanal.UserId,
            UserEmail = user.Email,
            ChannelName = kanal.Name,
        };

        Log.Information("User successfully added to the channel. UserId: {UserId}, KanalId: {KanalId}", dto.UserId, dto.ChannelId);
        return new BaseResponse<GetUserChannelDto>(newDto, true, "User successfully added to the channel.");
    }

    public async Task<BaseResponse<ICollection<GetUserDto>>> GetAllByKanalId(long kanalId)
    {
        var users = await _db.UserChannels
            .Where(x => x.СhannelId == kanalId && !x.isDeleted)
            .Include(x => x.User)
            .ToListAsync();

        if (!users.Any())
        {
            Log.Information("No data found for KanalId: {KanalId}", kanalId);
            return new BaseResponse<ICollection<GetUserDto>>(null, false, "Нет данных для данного KanalId.");
        }

        var dto = users.Select(user => new GetUserDto
        {
            FullName = user.User.FullName,
            Email = user.User.Email,
            id = user.User.id,
            Role = user.User.Role,
            CreateAt = user.CreateAt,
            isDeleted = user.isDeleted
        }).ToList();

        Log.Information("Fetched users for KanalId: {KanalId}, UserCount: {UserCount}", kanalId, dto.Count);
        return new BaseResponse<ICollection<GetUserDto>>(dto, true, "");
    }

    public async Task<BaseResponse<ICollection<GetChannelDto>>> GetAllByUserId(long userId)
    {
        var kanals = await _db.UserChannels
            .Where(x => x.UserId == userId && !x.isDeleted)
            .Include(x => x.Сhannel)
            .ToListAsync();

        if (!kanals.Any())
        {
            Log.Information("No data found for UserId: {UserId}", userId);
            return new BaseResponse<ICollection<GetChannelDto>>(null, false, "Нет данных для данного UserId.");
        }

        var dto = kanals.Select(kanal => new GetChannelDto
        {
            id = kanal.Сhannel.id,
            Name = kanal.Сhannel.Name,
            CreateAt = kanal.Сhannel.CreateAt,
            Type = kanal.Сhannel.Type.ToString(),
            isDeleted = kanal.Сhannel.isDeleted
        }).ToList();

        Log.Information("Fetched kanals for UserId: {UserId}, KanalCount: {KanalCount}", userId, dto.Count);
        return new BaseResponse<ICollection<GetChannelDto>>(dto, true, "");
    }

    public async Task<BaseResponse<GetUserChannelDto>> RemoveUserKanalAsync(long userId, long kanalId)
    {
        var userKanal = await _db.UserChannels.SingleOrDefaultAsync(x => x.СhannelId == kanalId && x.UserId == userId && !x.isDeleted);

        if (userKanal == null)
        {
            Log.Information("UserKanal not found. UserId: {UserId}, KanalId: {KanalId}", userId, kanalId);
            return new BaseResponse<GetUserChannelDto>(null, false, "");
        }

        userKanal.isDeleted = true;
        _db.UserChannels.Update(userKanal);
        await _db.SaveChangesAsync();

        var dto = new GetUserChannelDto
        {
            ChannelId = userKanal.СhannelId,
            UserId = userKanal.UserId,
        };

        Log.Information("User successfully removed from Kanal. UserId: {UserId}, KanalId: {KanalId}", userId, kanalId);
        return new BaseResponse<GetUserChannelDto>(dto, true, "");
    }
}
