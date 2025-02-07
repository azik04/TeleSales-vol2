using AutoMapper;
using TeleSales.Core.Dto.Main.User;
using TeleSales.DataProvider.Entities.Main;

namespace TeleSales.Core.Mapper.Main.User;

public class GetUserProfile : Profile
{
    public GetUserProfile()
    {
        CreateMap<GetUserDto, Users>()
            .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id));
    }
}
