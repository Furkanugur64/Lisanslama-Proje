using Azure.Core;
using FluentValidation;
using LisansProje.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebApi.Abstract;
using WebApi.Concrete;
using WebApi.Models;
using WebApi.Models.DTO;

namespace WebApi.Controllers
{
    public class LisansController : ApiControllerBase
    {       
        ILisansService _lisansmanager;        
        private readonly IValidator<LisansDTO> _validator;

        public LisansController(IValidator<LisansDTO> validator,ILisansService lisansService)
        {
            _lisansmanager = lisansService;          
            _validator = validator;
        }      

        [HttpPost]
        [Route("Lisanskontrol")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Lisans>> LisansiGetir(LisansDTO lisansdto)
        {
            var validationResult = _validator.Validate(lisansdto);
            if (validationResult.IsValid)
            {
                var lisans = _lisansmanager.LisansGetir(lisansdto);

                if (lisans != null)
                {
                    var lisansGetirDTO = _lisansmanager.LisansDonustur(lisans);

                    return Ok(lisansGetirDTO);
                }
                else
                {
                    return BadRequest("Lisans Bulunamadı");
                }
            }
            else
            {
                return BadRequest("Tüm alanları doldurun !");
            }

        }
    }
}
