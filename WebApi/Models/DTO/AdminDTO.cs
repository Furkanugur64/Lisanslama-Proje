using FluentValidation;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace WebApi.Models.DTO
{
    public class AdminDTO
    {
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
    }

    public class AdminValidator : AbstractValidator<AdminDTO>
    {
        public AdminValidator()
        {
            RuleFor(user => user.KullaniciAdi).NotEmpty().WithMessage("Kullanıcı Adı Boş Geçilemez !!"); 
            RuleFor(user => user.Sifre).NotEmpty().WithMessage("Şifre Boş Geçilemez !!");
        }
    }
}
