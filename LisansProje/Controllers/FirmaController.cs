using FluentValidation;
using LisansProje.Abstract;
using LisansProje.Concrete;
using LisansProje.Models;
using LisansProje.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System.Runtime.Intrinsics.Arm;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace LisansProje.Controllers
{
    public class FirmaController : Controller
    {
        IFirmaService _firmaManager;
        private readonly IValidator<Firma> _validator;
        private readonly IValidator<FirmaDTO> _validatorekle;
        private readonly IValidator<Urun> _validatorUrun;

        public FirmaController(IFirmaService firmamanager, IValidator<Firma> validatorfirma, IValidator<FirmaDTO> validatorekle, IValidator<Urun> validatorUrun)
        {
            _firmaManager = firmamanager;
            _validator = validatorfirma;
            _validatorekle = validatorekle;
            _validatorUrun = validatorUrun;
        }

        public IActionResult FirmaGirisSayfasi()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FirmaGirisSayfasi(FirmaDTO firma)
        {
            var validationResult = _validatorekle.Validate(firma);
            if(validationResult.IsValid)
            {
                var company = _firmaManager.FirmaKontrolEt(firma);
                if (company != null)
                {
                    HttpContext.Session.SetString("firma", company.FirmaAdi);
                    HttpContext.Session.SetString("mail", company.Email);
                    HttpContext.Session.SetInt32("id", company.FirmaID);                   
                    return Json(new { firma = true });
                }
                else
                {
                    return Json(new { firma = false });
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


        public IActionResult KayitOl()
        {
            return View();
        }

        [HttpPost]
		public IActionResult KayitOl(Firma firma)
		{
			var validationResult = _validator.Validate(firma);
			if (validationResult.IsValid)
			{				
				_firmaManager.FirmaKaydet(firma);
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

        public IActionResult UrunGetir()
        {
            FirmaBilgi();
            return View();
        }
        [HttpPost]
        public IActionResult UrunGetir(int id)
        {
            var firmaid = HttpContext.Session.GetInt32("id");
            var urun = _firmaManager.UrunGetir(Convert.ToInt32(firmaid));         
            return Json(new { recordsFiltered = urun.Count , recordsTotal = urun.Count, data = urun });

        }

        public IActionResult UrunEkle()
        {
            FirmaBilgi();
            return View();
        }
        [HttpPost]
        public IActionResult UrunEkle(Urun urun)
        {
            var validationResult = _validatorUrun.Validate(urun);
            if (validationResult.IsValid)
            {
                var FirmaId = HttpContext.Session.GetInt32("id");
                _firmaManager.UrunKaydet(urun,Convert.ToInt32( FirmaId));
                return Json(new { SONUC = true ,protokol=urun.ProtokolNo,servis=urun.ServisUrl});
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


        public PartialViewResult FirmaDetay(int id)
        {
            var firma = _firmaManager.FirmaDetay(id);
            return PartialView("_FirmaDetayPartialView", firma);
        }

        [HttpPost]
        public IActionResult FirmaGuncelle(Firma firma)
        {
            var validationResult = _validator.Validate(firma);
            if (validationResult.IsValid)
            {
                HttpContext.Session.SetString("firma", firma.FirmaAdi);
                HttpContext.Session.SetString("mail", firma.Email);
                _firmaManager.FirmaGuncelle(firma);
                return Json(new { SONUC = true, ad = firma.FirmaAdi, mail = firma.Email });
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

        public void FirmaBilgi()
        {
            ViewBag.firma = HttpContext.Session.GetString("firma");
            ViewBag.mail = HttpContext.Session.GetString("mail");
            ViewBag.id = HttpContext.Session.GetInt32("id");
        }
    }
}
