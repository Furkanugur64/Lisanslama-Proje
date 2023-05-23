using FluentValidation;
using LisansProje.Models;

namespace LisansProje.ValidationRules
{
    public class UrunValidator : AbstractValidator<Urun>
    {
        public UrunValidator()
        {
            RuleFor(x => x.UrunAdi).NotEmpty().WithMessage("Ürün Adı Boş Geçilemez !!");
            RuleFor(x => x.WebSitesi).NotEmpty().WithMessage("Web Sitesi Boş Geçilemez !!");         
        }
    }
}
