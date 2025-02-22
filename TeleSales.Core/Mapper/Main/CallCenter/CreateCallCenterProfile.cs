using AutoMapper;
using TeleSales.Core.Dto.Main.CallCenter;
using TeleSales.DataProvider.Entities.Main;

namespace TeleSales.Core.Mapper.Main.CallCenter;

public class CreateCallCenterProfile : Profile
{
    public CreateCallCenterProfile()
    {
        CreateMap<CreateCallCenterDto, CallCenters>()
          .ForMember(dest => dest.ChannelId, opt => opt.MapFrom(src => src.ChannelId)) // Fixed here
          .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName))
          .ForMember(dest => dest.RegionId, opt => opt.MapFrom(src => src.RegionId))
          .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
          .ForMember(dest => dest.ExcludedBy, opt => opt.MapFrom(src => src.ExcludedBy))
          .ForMember(dest => dest.VOEN, opt => opt.MapFrom(src => src.VOEN))
          .ForMember(dest => dest.ApplicationTypeId, opt => opt.MapFrom(src => src.ApplicationTypeId))
          .ForMember(dest => dest.ShortContent, opt => opt.MapFrom(src => src.ShortContent))
          .ForMember(dest => dest.DetailsContent, opt => opt.MapFrom(src => src.DetailsContent))
          .ForMember(dest => dest.isForwarding, opt => opt.MapFrom(src => src.isForwarding))
          .ForMember(dest => dest.AdministrationId, opt => opt.MapFrom(src => src.AdministrationId))
          .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.DepartmentId))
          .ForMember(dest => dest.EmployerId, opt => opt.MapFrom(src => src.EmployerId))
          .ForMember(dest => dest.Conclusion, opt => opt.MapFrom(src => src.Conclusion))
          .ForMember(dest => dest.Addition, opt => opt.MapFrom(src => src.Addition))
          .ForMember(dest => dest.CreateAt, opt => opt.MapFrom(src => DateTime.Now));
    }
}
