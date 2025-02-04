using AutoMapper;
using TeleSales.Core.Dto.Main.CallCenter;
using TeleSales.DataProvider.Entities.Main;

namespace TeleSales.Core.Mapper.Main.CallCenter;

public class GetCallCenterProfile : Profile
{
    public GetCallCenterProfile()
    {
        CreateMap <CallCenters, GetCallCenterDto>()
            .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => src.isDeleted));
    }
}
