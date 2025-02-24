using AutoMapper;
using TeleSales.Core.Dto.Main.Uzadilma;
using TeleSales.DataProvider.Entities.Main;

namespace TeleSales.Core.Mapper.Main.Uzadilma;

public class UpdateUzadilmaProfile : Profile
{
    public UpdateUzadilmaProfile()
    {
        CreateMap<CreateUzadilmaDto, Uzadilmas>()
            .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.DepartmentId))
            .ForMember(dest => dest.RegionId, opt => opt.MapFrom(src => src.RegionId))
            .ForMember(dest => dest.Adress, opt => opt.MapFrom(src => src.Adress))
            .ForMember(dest => dest.MuraciyetNomresi, opt => opt.MapFrom(src => src.MuraciyetNomresi))
            .ForMember(dest => dest.PermissionStartDate, opt => opt.MapFrom(src => src.PermissionStartDate))
            .ForMember(dest => dest.PermissionEndDate, opt => opt.MapFrom(src => src.PermissionEndDate))
            .ForMember(dest => dest.Yayici, opt => opt.MapFrom(src => src.Yayici))
            .ForMember(dest => dest.VOEN, opt => opt.MapFrom(src => src.VOEN))
            .ForMember(dest => dest.Zona, opt => opt.MapFrom(src => src.Zona))
            .ForMember(dest => dest.DasiyiciNovu, opt => opt.MapFrom(src => src.DasiyiciNovu))
            .ForMember(dest => dest.IcazeMuddeti, opt => opt.MapFrom(src => src.IcazeMuddeti))
            .ForMember(dest => dest.TəyinatVöen, opt => opt.MapFrom(src => src.TəyinatVöen))
            .ForMember(dest => dest.MüraciətSayı, opt => opt.MapFrom(src => src.MüraciətSayı))
            .ForMember(dest => dest.DaşıyıcıSayı, opt => opt.MapFrom(src => src.DaşıyıcıSayı));
    }   
}
