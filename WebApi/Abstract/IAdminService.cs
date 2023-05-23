using LisansProje.Models;
using WebApi.Models.DTO;

namespace WebApi.Abstract
{
    public interface IAdminService
    {
        Admin AdminKontrol(AdminDTO admin);

        String TokenOlustur(Admin admin);

    }
}
