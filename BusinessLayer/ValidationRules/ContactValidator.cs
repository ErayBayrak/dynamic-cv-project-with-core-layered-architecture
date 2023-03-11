using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.NameSurname).NotEmpty().WithMessage("Ad-Soyad Boş Geçilemez");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Boş Geçilemez");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail Boş Geçilemez");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj Boş Geçilemez");
            RuleFor(x => x.NameSurname).MinimumLength(5).WithMessage("Mesaj Boş Geçilemez");
        }
    }
}
