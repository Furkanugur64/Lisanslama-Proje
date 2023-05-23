using FluentValidation;
using LisansProje.Abstract;
using LisansProje.Concrete;
using LisansProje.Models;
using LisansProje.Models.Context;
using Microsoft.AspNetCore.Mvc;


namespace LisansProje.Controllers
{
	public class LoginController : Controller
	{        
        ILoginService _loginManager;
        private readonly IValidator<Admin> _validator;

        public LoginController(ILoginService loginService, IValidator<Admin> validatoradmin)
        {
            _loginManager = loginService;  
            _validator = validatoradmin;  
        }
        public IActionResult GirisYap()
		{
			return View();
		}

        [HttpPost]
        public IActionResult GirisYap(Admin admin)
        {
            var validationResult = _validator.Validate(admin);
            if(validationResult.IsValid)
            {
                var adm = _loginManager.AdminKontrolEt(admin);
                if(adm != null) {
                    int id = adm.ID;
                    TempData["AdminId"] = id;
                    TempData["AdminAd"] = adm.KullaniciAdi;
                    HttpContext.Session.SetString("ad", adm.KullaniciAdi);
                    HttpContext.Session.SetString("mail", adm.Mail);
                    HttpContext.Session.SetInt32("adminid", id);
                    return Json(new { admin = true });
                }
                else
                {
                    return Json(new { admin = false});
                }
            }     
            else
            {
                var errorMessages = new List<string>();

                foreach (var validationError in validationResult.Errors)
                {
                    errorMessages.Add(validationError.ErrorMessage);
                }
                return Json(new { SONUC = false, errors = errorMessages });
			}
        }

     

    }
}
