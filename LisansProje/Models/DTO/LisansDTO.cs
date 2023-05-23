using FluentValidation;

namespace LisansProje.Models.DTO
{
	public class LisansDTO
	{		
		public int LisansID { get; set; }
		
		public DateTime LisansBaslangicTarihi { get; set; }
		
		public int ToplamYil { get; set; }
		public DateTime LisansBitisTarihi { get; set; }

		public int LisansKisiSayisi { get; set; }

        public virtual Kurum Kurums { get; set; }
        public int KurumID { get; set; }

        public string KurumIpAdresi { get; set; }

		public string YazilimAdi { get; set; }

		public string YazilimProtokolNo { get; set; }
		public string LisansKodu { get; set; }
		public Guid SifreliId { get; set; }
		public byte Durum { get; set; }

		public DateTime KayitTarihi { get; set; }
		public int Kaydeden_K_Id { get; set; }
		public DateTime DegisiklikTarihi { get; set; }
		public int Degistiren_K_Id { get; set; }
	}

    public class LisansDTOValidator : AbstractValidator<LisansDTO>
    {
        public LisansDTOValidator()
        {
            RuleFor(x => x.LisansBaslangicTarihi).NotEmpty().WithMessage("Lisans Başlangıç Tarihi Boş Geçilemez !!");
            RuleFor(x => x.Kurums.KurumAdi).NotEmpty().WithMessage("Kurum Adı Boş Geçilemez !!");
            RuleFor(x => x.KurumIpAdresi).NotEmpty().WithMessage("Kurum İp Adresi Boş Geçilemez !!");
            RuleFor(x => x.YazilimAdi).NotEmpty().WithMessage("Yazılım Adı Boş Geçilemez !!");
            RuleFor(x => x.YazilimProtokolNo).NotEmpty().WithMessage("Yazılım Protokol Numarası Boş Geçilemez !!");
        }
    }
}
