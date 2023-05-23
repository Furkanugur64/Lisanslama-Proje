using LisansProje.Models;
using LisansProje.Models.DTO;

namespace LisansProje.Abstract
{
    public interface IFirmaService
    {
        Firma FirmaKontrolEt(FirmaDTO admin);

		void FirmaKaydet(Firma firma);

        void UrunKaydet(Urun urun,int firmaid);

        Firma FirmaDetay(int id);

        void FirmaGuncelle(Firma firma);

        List<Urun> UrunGetir(int id);
    }
}
