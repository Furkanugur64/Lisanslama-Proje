using FluentValidation;
using LisansProje.Models;

namespace LisansProje.ValidationRules
{
    public class LisansValidator : AbstractValidator<Lisans>
    {
        public LisansValidator() {           
            RuleFor(x => x.KurumID).NotEmpty().WithMessage("Kurum Adı Boş Geçilemez");
            RuleFor(x => x.LisansKisiSayisi).NotEmpty().WithMessage("Lisans Kişi Sayısı Boş Geçilemez");
            RuleFor(x => x.KurumIpAdresi).NotEmpty().WithMessage("Kurum İp Adresi Boş Geçilemez");
            RuleFor(x => x.YazilimAdi).NotEmpty().WithMessage("Yazılım Adı Boş Geçilemez");
            RuleFor(x => x.YazilimProtokolNo).NotEmpty().WithMessage("Yazılım Protokol Numarası Boş Geçilemez");
            RuleFor(x => x.ToplamYil).NotEmpty().WithMessage("Toplam Yıl Boş Geçilemez");            
        }

    }
}
