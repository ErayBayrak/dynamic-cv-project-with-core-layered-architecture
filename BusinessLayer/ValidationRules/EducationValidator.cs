using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class EducationValidator:AbstractValidator<Education>
    {
        public EducationValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık Boş Geçilemez");
            RuleFor(x => x.Subtitle1).NotEmpty().WithMessage("Başlık Boş Geçilemez");
            RuleFor(x => x.Subtitle2).NotEmpty().WithMessage("Başlık Boş Geçilemez");
            RuleFor(x => x.GPA).NotEmpty().WithMessage("Başlık Boş Geçilemez");
            RuleFor(x => x.EducationDate).NotEmpty().WithMessage("Başlık Boş Geçilemez");
        }
    }
}
