using FluentValidation;
using LisansProje.Abstract;
using LisansProje.Concrete;
using LisansProje.Models;
using LisansProje.Models.Context;
using LisansProje.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Globalization;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace LisansProje.Controllers
{
    public class LisansController : Controller
    {
        ILisansService _lisansManager;
        ILoginService _loginManager;
        private readonly IValidator<Lisans> _validator;
        private readonly IValidator<Admin> _validatorAdmin;
        private readonly IValidator<AdminDTO> _validatorAdminEkle;
        

        public LisansController(IValidator<Lisans> validator, ILisansService lisansService, ILoginService loginManager,IValidator<Admin> validatorAdmin, IValidator<AdminDTO> validatorAdminEkle)
        {
            _lisansManager = lisansService;
            _validator = validator;
            _loginManager = loginManager;
            _validatorAdmin = validatorAdmin;
            _validatorAdminEkle = validatorAdminEkle;
        }

        public PartialViewResult LisansSayfasi()
        {
            ViewBag.dgr1 = _lisansManager.KurumGetir();
            var lisans = new LisansDTO();
            lisans.LisansBaslangicTarihi = DateTime.Parse(DateTime.Now.ToShortDateString());
            lisans.ToplamYil = 1;
            lisans.LisansKisiSayisi = 1;
            return PartialView("_LisansEklePartialView", lisans);
        }
        [HttpPost]
        public IActionResult LisansSayfasi(Lisans lisans)
        {
            var validationResult = _validator.Validate(lisans);
            if (validationResult.IsValid)
            {
                var adminId = HttpContext.Session.GetInt32("adminid");
                _lisansManager.LisansKaydet(lisans, Convert.ToInt32(adminId));               
                return Json(new { SONUC = true });
            }
            else
            {
                var errorMessages = new List<string>();

                foreach (var validationError in validationResult.Errors)
                {
                    errorMessages.Add(validationError.ErrorMessage);
                }
                return Json(new { SONUC = false ,errors=errorMessages});
            }
        }

        public IActionResult LisansGetir()
        {
            ViewBag.dgr1 = _lisansManager.KurumGetir();
            KullanıcıBilgi();
            return View();
        }

        [HttpPost]
        public IActionResult LisansGetir(int status, int start, int length)
        {           
            ViewBag.id = HttpContext.Session.GetInt32("adminid");
            if (length == 0){length = 10;}
            var lisans = _lisansManager.LisansGetir(status, start, length);
            int toplamLisansSayisi = _lisansManager.ToplamLisansSayisi(status);
            return Json(new { recordsFiltered = toplamLisansSayisi, recordsTotal = toplamLisansSayisi, data = lisans});
        }


        public PartialViewResult LisansDetay(int id)
        {
            ViewBag.dgr1 = _lisansManager.KurumGetir();
            var lisans = _lisansManager.LisansDetay(id);
            if (lisans != null)
            {
                ViewBag.drm = lisans.Durum;
            }
            return PartialView("_LisansDetayPartialView", lisans);

        }

        [HttpPost]
        public IActionResult LisansGuncelle(Lisans lisans)
        {
            var validationResult = _validator.Validate(lisans);
            if (validationResult.IsValid)
            {
                var adminId = HttpContext.Session.GetInt32("adminid");
                _lisansManager.LisansGuncelle(lisans, Convert.ToInt32(adminId));
                return Json(new { SONUC = true });
            }
            else
            {
                var errorMessages = new List<string>();

                foreach (var validationError in validationResult.Errors)
                {
                    errorMessages.Add(validationError.ErrorMessage);
                }
                return Json(new { SONUC = false ,errors=errorMessages}) ;
            }

        }

        public IActionResult LisansDurumDegistir(int id, int durum)
        {
            var adminId = HttpContext.Session.GetInt32("adminid");
            _lisansManager.LisansDurumDegistir(id, durum, Convert.ToInt32(adminId));
            return Json(new { SONUC = true });
        }

        public IActionResult LisansEklePartialView()
        {
            var lisansViewModel = new LisansViewModel();
            return PartialView("_LisansEkleModal", lisansViewModel);
        }

        public IActionResult LisansDetayPartialView(int id)
        {
            var lisans = _lisansManager.LisansDetay(id);
            return Json(new { data = lisans });
        }

      

        public PartialViewResult AdminDetay(int id)
        {
            var admin = _loginManager.AdminDetay(id);          
            return PartialView("_AdminDetayPartialView", admin);
        }

        [HttpPost]
        public IActionResult AdminGuncelle(AdminDTO admin)
        {
            var validationResult = _validatorAdminEkle.Validate(admin);            
            if (validationResult.IsValid)
            {             
                _loginManager.AdminGuncelle(admin);
                KullanıcıBilgi();
                ViewBag.kadi = admin.KullaniciAdi;
                ViewBag.mail = admin.Mail;
                return Json(new { SONUC = true, ad=admin.KullaniciAdi, mail=admin.Mail });
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

        public IActionResult LisansEkle()
        {
            ViewBag.dgr1 = _lisansManager.KurumGetir();
            KullanıcıBilgi();         
            var lisans = new LisansDTO();
            lisans.LisansBaslangicTarihi = DateTime.Parse(DateTime.Now.ToShortDateString());
            lisans.ToplamYil = 1;
            lisans.LisansKisiSayisi = 1;
            return View(lisans);
        }

        public void KullanıcıBilgi() {
            ViewBag.kadi = HttpContext.Session.GetString("ad");
            ViewBag.mail = HttpContext.Session.GetString("mail");
            ViewBag.id = HttpContext.Session.GetInt32("adminid");
        }

        public IActionResult LisansFiltrele(string lisanskodu,int kurumadi, string lisansbaslangictarihi,string lisansbitistarihi,int durum)
        {
            var lisans= _lisansManager.LisansFiltrele(lisanskodu, kurumadi, lisansbaslangictarihi, lisansbitistarihi,durum);
            return Json(new { recordsFiltered = lisans.Count, recordsTotal = lisans.Count, data = lisans });
        }
    }
}
