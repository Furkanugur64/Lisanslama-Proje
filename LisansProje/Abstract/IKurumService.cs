using LisansProje.Models;
using LisansProje.Models.Context;

namespace LisansProje.Abstract
{
  
    public interface IKurumService
    {
        List<Kurum> KurumGetir(int durum);

        void KurumSil(int id);

        void KurumKaydet(Kurum kurum);
        void KurumGuncelle(Kurum kurum);

        Kurum KurumDetay(int id);

        List<Kurum> KurumFiltrele(string kurumAdi);
    }
}
