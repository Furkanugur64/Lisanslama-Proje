using FluentValidation;
using LisansProje.Models;
using LisansProje.Models.DTO;

namespace LisansProje.ValidationRules
{
	public class FirmaEkleValidator : AbstractValidator<FirmaDTO>
	{
		public FirmaEkleValidator()
		{
			RuleFor(x => x.Email).NotEmpty().WithMessage("Email Adresi Boş Geçilemez");
			RuleFor(x => x.Parola).NotEmpty().WithMessage("Şifre Boş Geçilemez");						
		}
	}
}
