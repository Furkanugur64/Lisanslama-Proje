using System.ComponentModel.DataAnnotations;

namespace LisansProje.Models
{
	public class Admin
	{
		[Key]
		public int ID { get; set; }
		public string KullaniciAdi { get; set; }
		public string Sifre { get; set; }
        public string Mail { get; set; }       
    }




}
