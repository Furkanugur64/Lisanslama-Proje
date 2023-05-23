using LisansProje.Models;

namespace WebApi.Models.DTO
{
    public class LisansGetirDTO
    {
        public string LisansKodu { get; set; }
        public DateTime LisansBaslangicTarihi { get; set; }

        public int ToplamYil { get; set; }
        public DateTime LisansBitisTarihi { get; set; }

        public int LisansKisiSayisi { get; set; }

        public string KurumAdi { get; set; }

        public string KurumIpAdresi { get; set; }
       
        public string YazilimAdi { get; set; }       
        public string YazilimProtokolNo { get; set; }

        public string KalanZaman { get; set; }
        
    }
}
