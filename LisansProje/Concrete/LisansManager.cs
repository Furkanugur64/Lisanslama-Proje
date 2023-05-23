using LisansProje.Abstract;
using LisansProje.Models;
using LisansProje.Models.Context;
using LisansProje.Models.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LisansProje.Concrete
{
    public class LisansManager : ILisansService
    {
        Context _applicationContext = new Context();

        public Lisans LisansDetay(int id)
        {
            var lisans = _applicationContext.Licences.Find(id);
            return lisans;
        }

        

        public void LisansDurumDegistir(int id, int durum, int admid)
        {
            var ls = _applicationContext.Licences.Find(id);
            if (ls != null)
            {
                ls.Durum = Convert.ToByte(durum);
                ls.Degistiren_K_Id = Convert.ToInt32(admid);
                ls.DegisiklikTarihi = DateTime.Now.Date;
                _applicationContext.SaveChanges();
            }
        }

        public List<Lisans> LisansFiltrele(string? lisanskodu, int? kurumadi, string? lisansbastarihi, string? lisansbittarihi, int durum)
        {                     

            var lisans = _applicationContext.Licences.Include(e => e.Kurums).AsQueryable();
            if (!string.IsNullOrEmpty(lisanskodu))
            {
                lisans = lisans.Where(x => x.LisansKodu == lisanskodu.Trim());
            }                                    
            if (!string.IsNullOrEmpty(lisansbastarihi))
            {
                var baslangicTarihi = DateTime.Parse(lisansbastarihi);
                lisans = lisans.Where(x => x.LisansBaslangicTarihi == baslangicTarihi);
            }

            if (kurumadi != 0 && kurumadi!=null)
            {
                lisans = lisans.Where(x => x.KurumID == kurumadi);
            }

            if (!string.IsNullOrEmpty(lisansbittarihi))
            {
                var bitisTarihi = DateTime.Parse(lisansbittarihi);
                lisans = lisans.Where(x => x.LisansBitisTarihi == bitisTarihi);
            }

            return lisans.Where(x=>x.Durum==durum).ToList();
        }

        public List<Lisans> LisansGetir(int? statu,int start,int length)
        {
            
            var lisans = _applicationContext.Licences
                .Include(e=>e.Kurums)
                .Where(l => l.Durum == statu)
                .Skip((((start + length) / length) - 1) * length)
                .Take(length)
                .ToList();
            return lisans;          

        }

        public void LisansGuncelle(Lisans lisans, int id)
        {
            var ls = _applicationContext.Licences.Find(lisans.LisansID);
            if (ls != null)
            {
                ls.LisansKisiSayisi = lisans.LisansKisiSayisi;
                ls.ToplamYil = lisans.ToplamYil;
                ls.LisansBaslangicTarihi = lisans.LisansBaslangicTarihi;
                ls.KurumID = lisans.KurumID;
                ls.DegisiklikTarihi = DateTime.Now.Date;
                ls.KurumIpAdresi = lisans.KurumIpAdresi;
                ls.YazilimAdi = lisans.YazilimAdi;
                ls.YazilimProtokolNo = lisans.YazilimProtokolNo;
                ls.Degistiren_K_Id = Convert.ToInt32(id);
                DateTime bitisTarihi = new DateTime(ls.LisansBaslangicTarihi.Year + ls.ToplamYil, ls.LisansBaslangicTarihi.Month, ls.LisansBaslangicTarihi.Day);
                ls.LisansBitisTarihi = bitisTarihi;
                _applicationContext.SaveChanges();
            }
        }

        public void LisansKaydet(Lisans lisans,int id)
        {
            DateTime baslangicTarihi = lisans.LisansBaslangicTarihi;
            DateTime bitisTarihi = new DateTime(baslangicTarihi.Year + lisans.ToplamYil, baslangicTarihi.Month, baslangicTarihi.Day);
            var adminId = id;
            string lisansKodu = LisansOlustur();
            Guid guid = Guid.NewGuid();
            lisans.DegisiklikTarihi = DateTime.Now.Date;
            lisans.KayitTarihi = DateTime.Now.Date;
            lisans.SifreliId = guid;
            lisans.Durum = 1;
            lisans.LisansKodu = lisansKodu;
            lisans.LisansBitisTarihi = bitisTarihi;
            if (adminId != null)
            {
                lisans.Kaydeden_K_Id = Convert.ToInt32(adminId);
            }
            _applicationContext.Licences.Add(lisans);
            _applicationContext.SaveChanges();
        }
        
        public string LisansOlustur()
        {
            string licenseKey = "";
            Random rnd = new Random();

            // 4 harf
            for (int i = 0; i < 4; i++)
            {
                char c = (char)rnd.Next('A', 'Z' + 1);
                licenseKey += c;
            }
            licenseKey += "-";
            // 4 sayı
            for (int i = 0; i < 4; i++)
            {
                int n = rnd.Next(0, 9);
                licenseKey += n.ToString();
            }
            licenseKey += "-";
            // 4 harf
            for (int i = 0; i < 4; i++)
            {
                char c = (char)rnd.Next('A', 'Z' + 1);
                licenseKey += c;
            }
            licenseKey += "-";
            // 4 sayı
            for (int i = 0; i < 4; i++)
            {
                int n = rnd.Next(0, 9);
                licenseKey += n.ToString();
            }
            licenseKey += "-";
            // 4 harf
            for (int i = 0; i < 4; i++)
            {
                char c = (char)rnd.Next('A', 'Z' + 1);
                licenseKey += c;
            }

            return licenseKey;

        }

        public int ToplamLisansSayisi(int statu)
        {
            int lisanssayisi = _applicationContext.Licences.Where(e => e.Durum == statu).Count();
            return lisanssayisi;
        }

        public List<SelectListItem> KurumGetir()
        {
            List<SelectListItem> deger1 = (from x in _applicationContext.Kurums.Where(p=>p.Durum==1).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KurumAdi,
                                               Value = x.ID.ToString()
                                           }).ToList();
            return deger1;
        }
    }
}
