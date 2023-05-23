using FluentValidation;
using LisansProje.Abstract;
using LisansProje.Concrete;
using LisansProje.Models;
using LisansProje.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace LisansProje.Controllers
{
    public class KurumController : Controller
    {
        IKurumService _kurumManager;
        private readonly IValidator<Kurum> _validator;

        public KurumController(IKurumService kurumManager, IValidator<Kurum> validatorkurum)
        {
            _kurumManager = kurumManager;
            _validator= validatorkurum;
        }
        public IActionResult KurumGetir()
        {
            KullanıcıBilgi();
            return View();
        }

        [HttpPost]
        public IActionResult KurumGetir(int durum)
        {
            ViewBag.id = HttpContext.Session.GetInt32("adminid");            
            var kurum = _kurumManager.KurumGetir(durum);
            return Json(new { recordsFiltered = kurum.Count, recordsTotal = kurum.Count, data = kurum });
        }

        public IActionResult KurumKaydet()
        {           
            return View();
        }

        public IActionResult KurumSil(int id)
        {
            _kurumManager.KurumSil(id);
            return Json(new { SONUC = true });
        }

        public PartialViewResult KurumEkle()
        {
            return PartialView("_KurumEklePartialView");
        }

        [HttpPost]
        public IActionResult KurumEkle(Kurum kurum)
        {
            var validationResult = _validator.Validate(kurum);
            if(validationResult.IsValid)
            {
                _kurumManager.KurumKaydet(kurum);
                return Json(new { success = true });
            }
            else
            {
                var errorMessages = new List<string>();

                foreach (var validationError in validationResult.Errors)
                {
                    errorMessages.Add(validationError.ErrorMessage);
                }
                return Json(new { success = false , errors = errorMessages });
            }
        }

        public IActionResult KurumDetay(int id)
        {
            var kurum=_kurumManager.KurumDetay(id);
            return PartialView("_KurumDetayPartialView",kurum);
        }

        [HttpPost]

        public IActionResult KurumGuncelle(Kurum kurum)
        {
            var validationResult = _validator.Validate(kurum);
            if (validationResult.IsValid)
            {
                _kurumManager.KurumGuncelle(kurum);
                return Json(new { SONUC = true });
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

        public IActionResult KurumFiltrele(string kurumAdi)
        {
            var kurum = _kurumManager.KurumFiltrele(kurumAdi);
            return Json(new { recordsFiltered = kurum.Count, recordsTotal = kurum.Count, data = kurum });
        }

        public void KullanıcıBilgi()
        {
            ViewBag.kadi = HttpContext.Session.GetString("ad");
            ViewBag.mail = HttpContext.Session.GetString("mail");
            ViewBag.id = HttpContext.Session.GetInt32("adminid");
        }
    }
}
