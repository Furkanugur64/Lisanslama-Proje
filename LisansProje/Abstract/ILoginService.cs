using LisansProje.Models;
using LisansProje.Models.DTO;

namespace LisansProje.Abstract
{
    public interface ILoginService
    {
        Admin AdminKontrolEt(Admin admin);

        Admin AdminDetay(int id);

        void AdminGuncelle(AdminDTO admin);
    }
}
