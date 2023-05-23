using System.ComponentModel.DataAnnotations;

namespace LisansProje.Models
{
	public class Lisans
	{
		[Key]		
		public int LisansID { get; set; }

		[Required(ErrorMessage = "Lisans Başlangıç Tarihi Boş Geçilemez")]
		public DateTime LisansBaslangicTarihi { get; set; }

		[Required(ErrorMessage = "Toplam Yıl Değeri Boş Geçilemez")]
		public int ToplamYil { get; set; }
        public DateTime LisansBitisTarihi { get; set; }

        [Required(ErrorMessage = "Lisans Kişi Sayısı Boş Geçilemez")]
		public int LisansKisiSayisi { get; set; }

		public virtual Kurum Kurums { get; set; }		
		public int KurumID { get; set; }

		[Required(ErrorMessage = "Kurum İp Adresi Boş Geçilemez")]
		public string KurumIpAdresi { get; set; }

		[Required(ErrorMessage = "Yazılım Adı Boş Geçilemez")]
		public string YazilimAdi { get; set; }

		[Required(ErrorMessage = "Yazılım Protokol Numarası Boş Geçilemez")]
		public string YazilimProtokolNo { get; set; }
		public string LisansKodu { get; set; }
        public Guid SifreliId { get; set; }
		public byte Durum { get; set; }

        public DateTime KayitTarihi { get; set; }
		public int Kaydeden_K_Id { get; set; }
        public DateTime DegisiklikTarihi { get; set; }
        public int Degistiren_K_Id { get; set; }


    }
}
