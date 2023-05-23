using FluentValidation;
using LisansProje.Models;

namespace LisansProje.ValidationRules
{
    public class KurumValidator : AbstractValidator<Kurum>
    {
        public KurumValidator()
        {
            RuleFor(x => x.KurumAdi).NotEmpty().WithMessage("Kurum Adı Boş Geçilemez !!");
        }
    }
}
