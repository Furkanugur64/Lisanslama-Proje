using System.ComponentModel.DataAnnotations;

namespace LisansProje.Models
{
    public class Firma
    {
        [Key]
        public int FirmaID { get; set; }
        public string FirmaAdi { get; set; }
        public string VergiNo { get; set; }
        public string Adres { get; set; }
        public string Il { get; set; }
        public string Ilce { get; set; }
        public string Email { get; set; }
        public string Parola { get; set; }
        public DateTime KayitTarihi { get; set; }
        public byte Durum { get; set; }
    }
}
