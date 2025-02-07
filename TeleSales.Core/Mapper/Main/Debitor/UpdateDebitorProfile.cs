using AutoMapper;
using TeleSales.Core.Dto.Main.Debitor;
using TeleSales.DataProvider.Entities.Main;

namespace TeleSales.Core.Mapper.Main.Debitor;

public class UpdateDebitorProfile : Profile
{
    public UpdateDebitorProfile()
    {
        CreateMap<UpdateDebitorDto, Debitors>()
            .ForMember(dest => dest.LegalName, opt => opt.MapFrom(src => src.LegalName))
            .ForMember(dest => dest.VOEN, opt => opt.MapFrom(src => src.VOEN))
            .ForMember(dest => dest.PermissionStartDate, opt => opt.MapFrom(src => src.PermissionStartDate))
            .ForMember(dest => dest.PermissionEndDate, opt => opt.MapFrom(src => src.PermissionEndDate))
            .ForMember(dest => dest.InvoiceNumber, opt => opt.MapFrom(src => src.InvoiceNumber))
            .ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.Subject))
            .ForMember(dest => dest.District, opt => opt.MapFrom(src => src.District))
            .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Street))
            .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone));
    }
}
