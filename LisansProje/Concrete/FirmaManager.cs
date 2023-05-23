using LisansProje.Abstract;
using LisansProje.Models;
using LisansProje.Models.Context;
using LisansProje.Models.DTO;

namespace LisansProje.Concrete
{
    public class FirmaManager : IFirmaService
    {
        Context _applicationcontext = new Context();

		public void FirmaKaydet(Firma firma)
		{
			firma.KayitTarihi = DateTime.Now.Date;
			firma.Durum = 1;
			_applicationcontext.Companys.Add(firma);
			_applicationcontext.SaveChanges();
		}

        public Firma FirmaDetay(int id)
        {
            var firma = _applicationcontext.Companys.Find(id);
            return firma;
        }

        public Firma FirmaKontrolEt(FirmaDTO firma)
        {
            var frm = _applicationcontext.Companys.FirstOrDefault(x => x.Email == firma.Email && x.Parola == firma.Parola);
            return frm;
        }

        public void FirmaGuncelle(Firma firma)
        {
            var fr = _applicationcontext.Companys.Find(firma.FirmaID);
            if (fr != null)
            {
                fr.FirmaAdi = firma.FirmaAdi;
                fr.VergiNo = firma.VergiNo;
                fr.Adres = firma.Adres;
                fr.Il = firma.Il;
                fr.Ilce = firma.Ilce;
                fr.Email = firma.Email;
                fr.Parola = firma.Parola;
                _applicationcontext.SaveChanges();
            } 
        }

        public void UrunKaydet(Urun urun, int firmaid)
        {
            string protokolNo = ProtokolNoOlustur();
            urun.ProtokolNo = protokolNo;
            urun.ServisUrl = "https://localhost:7267/api/Lisans/Lisanskontrol/"+protokolNo;
            urun.KayitTarihi = DateTime.Now.Date;
            urun.Durum = 1;
            urun.FirmaID = firmaid;
            _applicationcontext.Products.Add(urun);
            _applicationcontext.SaveChanges();
        }

        public string ProtokolNoOlustur()
        {
            string yil = DateTime.Now.Year.ToString();
            string ay = DateTime.Now.Month.ToString();
            if (Convert.ToInt32(ay) < 10)
            {
                ay = "0" + ay;
            }
            string gun = DateTime.Now.Day.ToString();
            if (Convert.ToInt32(gun) < 10)
            {
                gun = "0" + gun;
            }
            string saat = DateTime.Now.Hour.ToString();
            if (Convert.ToInt32(saat) < 10)
            {
                saat = "0" + saat;
            }
            string dakika = DateTime.Now.Minute.ToString();
            if (Convert.ToInt32(dakika) < 10)
            {
                dakika = "0" + dakika;
            }

            string protokokolNo = yil + ay + gun + saat + dakika;
            return protokokolNo;
        }

        public List<Urun> UrunGetir(int id)
        {
            var urunler = _applicationcontext.Products.Where(x => x.FirmaID == id).ToList();
            return urunler;
        }
    }
}
