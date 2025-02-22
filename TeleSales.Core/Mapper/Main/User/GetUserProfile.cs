using AutoMapper;
using TeleSales.Core.Dto.Main.User;
using TeleSales.DataProvider.Entities.Main;

namespace TeleSales.Core.Mapper.Main.User;

public class GetUserProfile : Profile
{
    public GetUserProfile()
    {
        CreateMap<Users, GetUserDto>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
    }
}
