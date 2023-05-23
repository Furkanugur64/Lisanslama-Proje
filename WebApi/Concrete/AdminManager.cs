using LisansProje.Models;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using WebApi.Abstract;
using WebApi.Concrete;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using WebApi.Models;
using WebApi.Models.DTO;

namespace WebApi.Concrete
{
    public class AdminManager : IAdminService
    {
        private readonly Context _applicationDbContext;

        public AdminManager(Context _Context)
        {
            _applicationDbContext = _Context;
        }

        public Admin AdminKontrol(AdminDTO admin)
        {
            try
            {
                var adm = _applicationDbContext.Admins.FirstOrDefault(u => u.KullaniciAdi == admin.KullaniciAdi && u.Sifre == admin.Sifre);

                if (adm != null)
                {
                    return adm;
                }
                else
                {
                    throw new Exception("Admin bilgisi bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string TokenOlustur(Admin admin)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("64A63153-11C1-4919-9133-EFAF99A9B456");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, admin.KullaniciAdi),
                   new Claim(ClaimTypes.Role, "Admin")
                }),
                Expires = DateTime.Now.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),

            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}


