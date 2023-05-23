using FluentValidation;
using LisansProje.Models;
using LisansProje.Models.DTO;

namespace LisansProje.ValidationRules
{
    public class AdminValidator : AbstractValidator<Admin>
    {
        public AdminValidator()
        {
            RuleFor(x => x.KullaniciAdi).NotEmpty().WithMessage("Kullanıcı Adı Boş Geçilemez !!");
            RuleFor(x => x.Sifre).NotEmpty().WithMessage("Şifre Boş Geçilemez !!");                                                                                            
        }
    }
}
