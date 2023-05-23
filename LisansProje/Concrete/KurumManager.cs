using LisansProje.Abstract;
using LisansProje.Models;
using LisansProje.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace LisansProje.Concrete
{
    public class KurumManager : IKurumService
    {
        Context _applicationContext = new Context();

        public Kurum KurumDetay(int id)
        {
            var kurum = _applicationContext.Kurums.Find(id);           
            return kurum;            
        }

        public List<Kurum> KurumGetir(int durum)
        {           
            var kurum = _applicationContext.Kurums.Where(p => p.Durum == 1).ToList();
            return kurum;
        }

        public void KurumGuncelle(Kurum kurum)
        {
            var krm = _applicationContext.Kurums.Find(kurum.ID);
            if (krm != null)
            {
                krm.KurumAdi = kurum.KurumAdi;
                _applicationContext.SaveChanges();
            }       
        }

        public void KurumKaydet(Kurum kurum)
        {
            kurum.Durum = 1;
            kurum.KayitTarihi= DateTime.Now.Date;
            _applicationContext.Kurums.Add(kurum);
            _applicationContext.SaveChanges();
        }

        public void KurumSil(int id)
        {
            var kurum = _applicationContext.Kurums.Find(id);
            if (kurum != null)
            {
                kurum.Durum = 2;
            }
            _applicationContext.SaveChanges();
        }

        public List<Kurum> KurumFiltrele(string? kurumAdi)
        {
            var kurum = _applicationContext.Kurums.Where(x => x.KurumAdi == kurumAdi).ToList();
            return kurum.Where(x => x.Durum == 1).ToList();
        }
    }
}
