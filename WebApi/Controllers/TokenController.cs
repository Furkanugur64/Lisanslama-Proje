using FluentValidation;
using LisansProje.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApi.Abstract;
using WebApi.Concrete;
using WebApi.Models;
using WebApi.Models.DTO;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace WebApi.Controllers
{
    public class TokenController : ApiControllerBase
    {       
        IAdminService _adminManager;
        private readonly IValidator<AdminDTO> _validator;

        public TokenController(IValidator<AdminDTO> validator,IAdminService adminservice)
        {                   
            _adminManager = adminservice;
            _validator = validator;           
        }

        [HttpPost("KontrolEt")]
        public async Task<ActionResult<string>> Login(AdminDTO request)
        {
            var validationResult = _validator.Validate(request);
            if (validationResult.IsValid)
            {
                var admin = _adminManager.AdminKontrol(request);
                if (admin != null)
                {
                    string tkn = _adminManager.TokenOlustur(admin);
                    return Ok(new { token = _adminManager.TokenOlustur(admin) });
                }
                else
                {
                    return BadRequest("Böyle Bir Kullanıcı Bulunumadı");
                }
            }
            else
            {
                return BadRequest("Tüm alanları doldurun !");
            }
            
        }
        
    }
}
