using FluentValidation;
using LisansProje.Models;
using LisansProje.Models.DTO;

namespace LisansProje.ValidationRules
{
    public class AdminEkleValidator : AbstractValidator<AdminDTO>
    {
        public AdminEkleValidator()
        {
            RuleFor(x => x.KullaniciAdi).NotEmpty().WithMessage("Kullanıcı Adı Boş Geçilemez !!");
            RuleFor(x => x.Sifre).NotEmpty().WithMessage("Şifre Boş Geçilemez !!");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail Boş Geçilemez !!");
        }
    
    }
}
