using System.ComponentModel.DataAnnotations;

namespace LisansProje.Models
{
    public class Urun
    {
        [Key]
        public int UrunID { get; set; }
        public string UrunAdi { get; set; }
        public string WebSitesi { get; set; }
        public int FirmaID { get; set; }
        public virtual Firma Firmalar { get; set; }
        public DateTime KayitTarihi { get; set; }
        public byte Durum { get; set; }
        public string ServisUrl { get; set; }
        public string ProtokolNo { get; set; }
    }
}
