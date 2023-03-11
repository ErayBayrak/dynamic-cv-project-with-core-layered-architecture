using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AboutValidator:AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.Address).NotEmpty().WithMessage("Adres Boş Geçilemez");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad Boş Geçilemez");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad Boş Geçilemez");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Telefon Numarası Boş Geçilemez");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail Boş Geçilemez");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama Boş Geçilemez");
            
        }
    }
}
