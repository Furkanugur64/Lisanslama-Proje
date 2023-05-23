using LisansProje.Models;
using WebApi.Models.DTO;

namespace WebApi.Abstract
{
    public interface ILisansService
    {
        Lisans LisansGetir(LisansDTO lisans);

        LisansGetirDTO LisansDonustur(Lisans lisans);
            
        
    }
}
