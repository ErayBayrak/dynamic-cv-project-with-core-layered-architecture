using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CertificateValidator:AbstractValidator<Certificate>
    {
        public CertificateValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama Kısmı Boş Geçilemez");
            RuleFor(x => x.CertificateDate).NotEmpty().WithMessage("Tarih Kısmı Boş Geçilemez");
            RuleFor(x => x.Description).MaximumLength(250).WithMessage("Açıklama 250 Karakterden Fazla Olamaz");
        }
    }
}
