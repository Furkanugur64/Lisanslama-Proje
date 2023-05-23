using FluentValidation;
using LisansProje.Models;

namespace LisansProje.ValidationRules
{
    public class FirmaValidator : AbstractValidator<Firma>
    {
        public FirmaValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Mail Adresi Boş Geçilemez");
            RuleFor(x => x.Parola).NotEmpty().WithMessage("Şifre Boş Geçilemez");
			RuleFor(x => x.FirmaAdi).NotEmpty().WithMessage("Firma Adı Boş Geçilemez");
			RuleFor(x => x.VergiNo).NotEmpty().WithMessage("Vergi Numarası Boş Geçilemez");
			RuleFor(x => x.Adres).NotEmpty().WithMessage("Adres Alanı Boş Geçilemez");
			RuleFor(x => x.Il).NotEmpty().WithMessage("İl Alanı Boş Geçilemez");
			RuleFor(x => x.Ilce).NotEmpty().WithMessage("İlçe Alanı Boş Geçilemez");
		}
    }
}
