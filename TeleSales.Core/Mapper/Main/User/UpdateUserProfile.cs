using AutoMapper;
using TeleSales.Core.Dto.Main.User;
using TeleSales.DataProvider.Entities.Main;

namespace TeleSales.Core.Mapper.Main.User;

public class UpdateUserProfile : Profile
{
    public UpdateUserProfile() 
    {
        CreateMap<UpdateUserDto, Users>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
    }
}
