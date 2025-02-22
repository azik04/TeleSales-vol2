using AutoMapper;
using TeleSales.Core.Dto.Main.Debitor;
using TeleSales.DataProvider.Entities.Main;

namespace TeleSales.Core.Mapper.Main.Debitor;

public class GetDebitorProfile : Profile
{
    public GetDebitorProfile()
    {
        CreateMap<Debitors, GetDebitorDto>()
            .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => src.StatusId))
            .ForMember(dest => dest.StatusName, opt => opt.MapFrom(src => src.Status.Name))
            .ForMember(dest => dest.ChannelId, opt => opt.MapFrom(src => src.ChannelId))
            .ForMember(dest => dest.InvoiceNumber, opt => opt.MapFrom(src => src.InvoiceNumber))
            .ForMember(dest => dest.LegalName, opt => opt.MapFrom(src => src.LegalName))
            .ForMember(dest => dest.VOEN, opt => opt.MapFrom(src => src.VOEN))
            .ForMember(dest => dest.PermissionStartDate, opt => opt.MapFrom(src => src.PermissionStartDate))
            .ForMember(dest => dest.PermissionEndDate, opt => opt.MapFrom(src => src.PermissionEndDate))
            .ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.Subject))
            .ForMember(dest => dest.District, opt => opt.MapFrom(src => src.District))
            .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Street))
            .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
            .ForMember(dest => dest.isDone, opt => opt.MapFrom(src => src.isDone))
            .ForMember(dest => dest.ResultId, opt => opt.MapFrom(src => src.ResultId))
            .ForMember(dest => dest.ResultName, opt => opt.MapFrom(src => src.Result.Name))
            .ForMember(dest => dest.Note, opt => opt.MapFrom(src => src.Note))
            .ForMember(dest => dest.ExcludedBy, opt => opt.MapFrom(src => src.ExcludedBy))
            .ForMember(dest => dest.ExcludedByName, opt => opt.MapFrom(src => src.User.FullName))
            .ForMember(dest => dest.ResultId, opt => opt.MapFrom(src => src.ResultId))
            .ForMember(dest => dest.ResultName, opt => opt.MapFrom(src => src.Result.Name))
            .ForMember(dest => dest.NextCall, opt => opt.MapFrom(src => src.NextCall.ToString()))
            .ForMember(dest => dest.LastStatusUpdate, opt => opt.MapFrom(src => src.LastStatusUpdate.ToString()))
            .ForMember(dest => dest.LastStatusUpdate, opt => opt.MapFrom(src => src.LastStatusUpdate))
            .ForMember(dest => dest.NextCall, opt => opt.MapFrom(src => src.NextCall))
            .ForMember(dest => dest.TotalDebt, opt => opt.MapFrom(src => src.TotalDebt))
            .ForMember(dest => dest.Year2018, opt => opt.MapFrom(src => src.Year2018))
            .ForMember(dest => dest.Year2019, opt => opt.MapFrom(src => src.Year2019))
            .ForMember(dest => dest.Year2020, opt => opt.MapFrom(src => src.Year2020))
            .ForMember(dest => dest.Year2021, opt => opt.MapFrom(src => src.Year2021))
            .ForMember(dest => dest.Year2022, opt => opt.MapFrom(src => src.Year2022))
            .ForMember(dest => dest.Year2023, opt => opt.MapFrom(src => src.Year2023))
            .ForMember(dest => dest.Month1_2024, opt => opt.MapFrom(src => src.Month1_2024))
            .ForMember(dest => dest.Month2_2024, opt => opt.MapFrom(src => src.Month2_2024))
            .ForMember(dest => dest.Month3_2024, opt => opt.MapFrom(src => src.Month3_2024))
            .ForMember(dest => dest.Month4_2024, opt => opt.MapFrom(src => src.Month4_2024))
            .ForMember(dest => dest.Month5_2024, opt => opt.MapFrom(src => src.Month5_2024))
            .ForMember(dest => dest.Month6_2024, opt => opt.MapFrom(src => src.Month6_2024))
            .ForMember(dest => dest.Month7_2024, opt => opt.MapFrom(src => src.Month7_2024))
            .ForMember(dest => dest.Month8_2024, opt => opt.MapFrom(src => src.Month8_2024))
            .ForMember(dest => dest.Month9_2024, opt => opt.MapFrom(src => src.Month9_2024))
            .ForMember(dest => dest.Month10_2024, opt => opt.MapFrom(src => src.Month10_2024))
            .ForMember(dest => dest.Month11_2024, opt => opt.MapFrom(src => src.Month11_2024))
            .ForMember(dest => dest.Month12_2024, opt => opt.MapFrom(src => src.Month12_2024))
            .ForMember(dest => dest.Month1_2025, opt => opt.MapFrom(src => src.Month1_2025))
            .ForMember(dest => dest.Month2_2025, opt => opt.MapFrom(src => src.Month2_2025))
            .ForMember(dest => dest.Month3_2025, opt => opt.MapFrom(src => src.Month3_2025));

    }

}
