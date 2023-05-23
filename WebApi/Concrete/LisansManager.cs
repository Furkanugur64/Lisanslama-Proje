using LisansProje.Models;
using Microsoft.EntityFrameworkCore;
using WebApi.Abstract;
using WebApi.Models;
using WebApi.Models.DTO;

namespace WebApi.Concrete
{
    public class LisansManager : ILisansService
    {
        private readonly Context _applicationdbcontext;
        public LisansManager(Context _context)
        {
            _applicationdbcontext = _context;
        }

        public LisansGetirDTO LisansDonustur(Lisans lisans)
        {
            DateTime bugun = DateTime.Today;
            double gun;
            LisansGetirDTO lisansGetirDTO= new LisansGetirDTO();

            lisansGetirDTO.LisansBaslangicTarihi =lisans.LisansBaslangicTarihi;
            lisansGetirDTO.ToplamYil = lisans.ToplamYil;
            lisansGetirDTO.LisansBitisTarihi =lisans.LisansBitisTarihi;
            lisansGetirDTO.LisansKisiSayisi = lisans.LisansKisiSayisi;
            lisansGetirDTO.KurumAdi = lisans.Kurums.KurumAdi;
            lisansGetirDTO.KurumIpAdresi = lisans.KurumIpAdresi;
            lisansGetirDTO.YazilimAdi = lisans.YazilimAdi;
            lisansGetirDTO.YazilimProtokolNo = lisans.YazilimProtokolNo;
            lisansGetirDTO.LisansKodu = lisans.LisansKodu;
            
            TimeSpan fark = lisansGetirDTO.LisansBitisTarihi.Subtract(bugun);

            if (lisansGetirDTO.LisansBitisTarihi>bugun)
            {
                gun = fark.TotalDays;
                lisansGetirDTO.KalanZaman = "Lisansınızın Toplamda " + gun + " Gün Kullanım Hakkı Bulunmaktadır.";
            }
            else
            {
                lisansGetirDTO.KalanZaman = "Lisansınızın Kullanım Hakkı Dolmuştur !!";
            }           
            return lisansGetirDTO;
        }

        public Lisans LisansGetir(LisansDTO lisansdto)
        {
            try
            {
                var lisans = _applicationdbcontext.Licences.Include(e=>e.Kurums).FirstOrDefault(l => l.YazilimProtokolNo == lisansdto.YazilimProtokolNo);

                if (lisans != null)
                {
                    return lisans;                  
                }
                else
                {
                    throw new Exception("lisans bilgisi bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}


