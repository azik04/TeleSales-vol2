using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TeleSales.Core.Dto.Main.User;
using TeleSales.Core.Interfaces.Main.User;
using TeleSales.Core.Response;
using TeleSales.DataProvider.Context;
using TeleSales.DataProvider.Entities.Main;
using TeleSales.DataProvider.Enums;

namespace TeleSales.Core.Services.Main.User;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;
    public UserService(ApplicationDbContext db, IMapper mapper)
    {
        _mapper = mapper;
        _db = db;
    }
    public async Task<BaseResponse<GetUserDto>> Create(CreateUserDto dto)
    {
        var user = _mapper.Map<Users>(dto);
       
        await _db.Users.AddAsync(user);
        await _db.SaveChangesAsync();

        var center = _mapper.Map<GetUserDto>(dto);

        return new BaseResponse<GetUserDto>(center);
    }


    public async Task<BaseResponse<ICollection<GetUserDto>>> GetAll()
    {
        var users = await _db.Users.Where(x => !x.isDeleted && (x.Role == Role.Operator || x.Role == Role.BaşOperator)).ToListAsync();

        var userDtos = _mapper.Map<List<GetUserDto>>(users);

        return new BaseResponse<ICollection<GetUserDto>>(userDtos);
    }

    public async Task<BaseResponse<ICollection<GetUserDto>>> GetAllUser()
    {
        var users = _db.Users
            .Where(x => !x.isDeleted &&
                       x.Role == Role.Operator);

        var userDtos = _mapper.Map<List<GetUserDto>>(users);

        return new BaseResponse<ICollection<GetUserDto>>(userDtos);
    }


    public async Task<BaseResponse<ICollection<GetUserDto>>> GetAllViewer()
    {
        var users = _db.Users
            .Where(x => !x.isDeleted &&
                       x.Role == Role.Viewer);

        var userDtos = _mapper.Map<List<GetUserDto>>(users);

        return new BaseResponse<ICollection<GetUserDto>>(userDtos);
    }


    public async Task<BaseResponse<ICollection<GetUserDto>>> GetAllBasOperator()
    {
        var users = _db.Users
            .Where(x => !x.isDeleted &&
                       x.Role == Role.BaşOperator);

        var userDtos = _mapper.Map<List<GetUserDto>>(users);

        return new BaseResponse<ICollection<GetUserDto>>(userDtos);
    }


    public async Task<BaseResponse<ICollection<GetUserDto>>> GetAllAdmin()
    {
        var users = _db.Users.Where(x => !x.isDeleted && x.Role == Role.Admin);

        var userDtos = _mapper.Map<List<GetUserDto>>(users);

        return new BaseResponse<ICollection<GetUserDto>>(userDtos);
    }


    public async Task<BaseResponse<GetUserDto>> GetById(long id)
    {
        if (id == 0)
            return new BaseResponse<GetUserDto>(null, false, "Id cant be 0.");

        var user = await _db.Users.SingleOrDefaultAsync(x => x.id == id && !x.isDeleted);

        if (user == null)
            return new BaseResponse<GetUserDto>("User not found");
        
        var userDto = _mapper.Map<GetUserDto>(user);
        
        return new BaseResponse<GetUserDto>(userDto);
    }


    public async Task<BaseResponse<GetUserDto>> Update(long id, UpdateUserDto dto)
    {
        if (id == 0)
            return new BaseResponse<GetUserDto>(null, false, "Id cant be 0.");

        var user = await _db.Users.SingleOrDefaultAsync(x => x.id == id && !x.isDeleted);

        if (user == null)
            return new BaseResponse<GetUserDto>("User not found");

        var update = _mapper.Map<Users>(dto);

        _db.Users.Update(user);
        await _db.SaveChangesAsync();

        var userDto = _mapper.Map<GetUserDto>(user);

        return new BaseResponse<GetUserDto>(userDto);
    }


    public async Task<BaseResponse<GetUserDto>> ChangePassword(long id, ChangePasswordDto dto)
    {
        var user = await _db.Users.SingleOrDefaultAsync(x => x.id == id && !x.isDeleted);

        if (user == null)
            return new BaseResponse<GetUserDto>("User not found.");

        if (dto.OldPassword != user.Password)
            return new BaseResponse<GetUserDto>("Incorrect old password.");

        if (dto.NewPassword != dto.ConfirmNewPassword)
            return new BaseResponse<GetUserDto>("New password and confirmation do not match.");

        if (dto.NewPassword == dto.OldPassword)
            return new BaseResponse<GetUserDto>("New password cannot be the same as the old password.");

        user.Password = dto.NewPassword;

        _db.Users.Update(user);
        await _db.SaveChangesAsync();

        var userDto = _mapper.Map<GetUserDto>(user);

        return new BaseResponse<GetUserDto>(userDto);
    }



    public async Task<BaseResponse<GetUserDto>> ChangeRole(long id, Role role)
    {
        if (id == 0)
            return new BaseResponse<GetUserDto>(null, false, "Id cannot be 0.");

        var user = await _db.Users.SingleOrDefaultAsync(x => x.id == id && !x.isDeleted);
        if (user == null)
            return new BaseResponse<GetUserDto>(null, false, "User not found.");

        user.Role = role;

        _db.Users.Update(user);
        await _db.SaveChangesAsync();

        var userDto = _mapper.Map<GetUserDto>(user);

        return new BaseResponse<GetUserDto>(userDto, true, "Role updated successfully.");
    }



    public async Task<BaseResponse<GetUserDto>> Remove(long id)
    {
        if (id == 0)
            return new BaseResponse<GetUserDto>(null, false, "Id cant be 0.");

        var user = await _db.Users.SingleOrDefaultAsync(x => x.id == id);

        if (user == null)
        {
            return new BaseResponse<GetUserDto>("User not found");
        }

        user.isDeleted = true;
        _db.Users.Update(user);
        await _db.SaveChangesAsync();

        var userDto = _mapper.Map<GetUserDto>(user);

        return new BaseResponse<GetUserDto>(userDto);
    }

}
