using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ExperienceValidator:AbstractValidator<Experience>
    {
        public ExperienceValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık Boş Geçilemez.");
            RuleFor(x => x.Subtitle).NotEmpty().WithMessage("Alt Başlık Boş Geçilemez.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama Boş Geçilemez.");
            RuleFor(x => x.ExperienceTime).NotEmpty().WithMessage("Tarih Boş Geçilemez.");
            RuleFor(x => x.ExperienceTime).MinimumLength(13).WithMessage("Tarih Formatı 'May 23-Ağu 25' Formatında Olmalıdır");
            RuleFor(x => x.ExperienceTime).MaximumLength(13).WithMessage("Tarih Formatı 'May 23-Ağu 25' Formatında Olmalıdır");
        }
    }
}
