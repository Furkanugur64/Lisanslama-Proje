using FluentValidation;
using LisansProje.Models;

namespace WebApi.Models.DTO
{
    public class LisansDTO
    {       
        public string YazilimProtokolNo { get; set; }

    }

    public class LisansDTOValidator : AbstractValidator<LisansDTO>
    {
        public LisansDTOValidator()
        {            
            RuleFor(x => x.YazilimProtokolNo).NotEmpty().WithMessage("Yazılım Protokol Numarası Boş Geçilemez !!");         
        }
    }
}
