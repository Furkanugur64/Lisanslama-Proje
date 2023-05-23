using System.ComponentModel.DataAnnotations;

namespace LisansProje.Models
{
    public class Kurum
    {
        [Key]
        public int ID { get; set; }
        public string KurumAdi { get; set; }
        public byte Durum { get; set; }

        public DateTime KayitTarihi { get; set; }
    }
}
