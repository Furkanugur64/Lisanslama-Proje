using LisansProje.Abstract;
using LisansProje.Models;
using LisansProje.Models.Context;
using LisansProje.Models.DTO;

namespace LisansProje.Concrete
{
    public class LoginManager : ILoginService
    {
        Context _applicationcontext = new Context();

        public Admin AdminKontrolEt(Admin admin)
        {
            var adm = _applicationcontext.Admins.FirstOrDefault(u => u.KullaniciAdi == admin.KullaniciAdi && u.Sifre == admin.Sifre);
            return adm;
        }

        public Admin AdminDetay(int id)
        {
            var admin = _applicationcontext.Admins.Find(id);
            return admin;
        }

        public void AdminGuncelle(AdminDTO admin)
        {
            var adm = _applicationcontext.Admins.Find(admin.ID);
            if (adm != null)
            {
                adm.KullaniciAdi = admin.KullaniciAdi;
                adm.Sifre = admin.Sifre;
                adm.Mail = admin.Mail;
                _applicationcontext.SaveChanges();
            }
        }
    }
}
