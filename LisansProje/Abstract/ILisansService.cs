using LisansProje.Models;
using LisansProje.Models.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LisansProje.Abstract
{
    public interface ILisansService
    {
        void LisansKaydet(Lisans lisans,int id);

        List<Lisans> LisansGetir(int? statü, int sayfaSayisi, int toplamVeri);

        Lisans LisansDetay(int id);

        void LisansGuncelle(Lisans lisans,int id);

        void LisansDurumDegistir(int id,int durum,int admid);

        int ToplamLisansSayisi(int statu);

        List<Lisans> LisansFiltrele(string? lisanskodu, int? kurumadi, string? lisansbastarihi, string? lisansbittarihi,int durum);

        List<SelectListItem> KurumGetir();

    }
}
