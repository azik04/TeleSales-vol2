using FluentValidation;
using TeleSales.Core.Dto.Main.Uzadilma;

namespace TeleSales.Core.Validation.Main.Uzadilma;

public class CreateUzadilmaDtoValidation : AbstractValidator<CreateUzadilmaDto>
{
    public CreateUzadilmaDtoValidation()
    {
        RuleFor(x => x.DepartmentId).GreaterThan(0).WithMessage("Şöbə ID-si 0-dan böyük olmalıdır.");
        RuleFor(x => x.RegionId).GreaterThan(0).WithMessage("Region ID-si 0-dan böyük olmalıdır.");
        RuleFor(x => x.ChannelId).GreaterThan(0).WithMessage("Kanal ID-si 0-dan böyük olmalıdır.");

        RuleFor(x => x.Adress)
            .NotEmpty().WithMessage("Ünvan tələb olunur.");

        RuleFor(x => x.MuraciyetNomresi).GreaterThan(0).WithMessage("Müraciət nömrəsi 0-dan böyük olmalıdır.");

        RuleFor(x => x.PermissionStartDate)
            .LessThanOrEqualTo(x => x.PermissionEndDate)
            .When(x => x.PermissionStartDate.HasValue && x.PermissionEndDate.HasValue)
            .WithMessage("İcazə başlama tarixi bitmə tarixindən əvvəl və ya bərabər olmalıdır.")
            .NotEmpty().WithMessage("İcazənin başlanma tarixi tələb olunur.");


        RuleFor(x => x.PermissionEndDate)
            .NotEmpty().WithMessage("İcazənin başlanma tarixi tələb olunur.");

        RuleFor(x => x.Yayici)
            .NotEmpty().WithMessage("Yayımçı tələb olunur.")
            .MaximumLength(255).WithMessage("Yayımçı 255 simvoldan çox ola bilməz.");

        RuleFor(x => x.VOEN).GreaterThan(0).WithMessage("VOEN 0-dan böyük olmalıdır.");

        RuleFor(x => x.Zona)
            .NotEmpty().WithMessage("Zona tələb olunur.")
            .MaximumLength(255).WithMessage("Zona 255 simvoldan çox ola bilməz.");

        RuleFor(x => x.DasiyiciNovu)
            .NotEmpty().WithMessage("Daşıyıcı növü tələb olunur.")
            .MaximumLength(255).WithMessage("Daşıyıcı növü 255 simvoldan çox ola bilməz.");

        RuleFor(x => x.IcazeMuddeti)
            .NotEmpty().WithMessage("İcazə müddəti tələb olunur.")
            .MaximumLength(255).WithMessage("İcazə müddəti 255 simvoldan çox ola bilməz.");

        RuleFor(x => x.TəyinatVöen)
            .NotEmpty().WithMessage("Təyinat VÖEN tələb olunur.")
            .MaximumLength(255).WithMessage("Təyinat VÖEN 255 simvoldan çox ola bilməz.");

        RuleFor(x => x.MüraciətSayı)
            .NotEmpty().WithMessage("Müraciət sayı tələb olunur.")
            .MaximumLength(50).WithMessage("Müraciət sayı 50 simvoldan çox ola bilməz.");

        RuleFor(x => x.DaşıyıcıSayı)
            .NotEmpty().WithMessage("Daşıyıcı sayı tələb olunur.")
            .MaximumLength(50).WithMessage("Daşıyıcı sayı 50 simvoldan çox ola bilməz.");
    }
}