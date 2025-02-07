using AutoMapper;
using TeleSales.Core.Dto.Main.CallCenter;
using TeleSales.DataProvider.Entities.Main;

namespace TeleSales.Core.Mapper.Main.CallCenter
{
    public class GetCallCenterProfile : Profile
    {
        public GetCallCenterProfile()
        {
            CreateMap<CallCenters, GetCallCenterDto>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id))
                .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => src.isDeleted))
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name))
                .ForMember(dest => dest.EmployerName, opt => opt.MapFrom(src => src.Employer.FullName))
                .ForMember(dest => dest.AdministrationName, opt => opt.MapFrom(src => src.Administration.Name))
                .ForMember(dest => dest.RegionName, opt => opt.MapFrom(src => src.Region.Name))
                .ForMember(dest => dest.ApplicationTypeName, opt => opt.MapFrom(src => src.ApplicationType.Name))
                .ForMember(dest => dest.ExcludedByName, opt => opt.MapFrom(src => src.User.FullName)); 
        }
    }
}
