using AutoMapper;
using TeleSales.Core.Dto.Main.User;
using TeleSales.DataProvider.Entities.Main;

namespace TeleSales.Core.Mapper.Main.User
{
    public class CreateUserProfile : Profile
    {
        public CreateUserProfile()
        {
            CreateMap<CreateUserDto, Users>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));

        }
    }

}
