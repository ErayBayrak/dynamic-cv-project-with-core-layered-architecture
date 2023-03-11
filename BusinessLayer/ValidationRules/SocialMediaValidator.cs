using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class SocialMediaValidator:AbstractValidator<SocialMedia>
    {
        public SocialMediaValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Sosyal Medya Adı Boş Geçilemez");
            RuleFor(x => x.Link).NotEmpty().WithMessage("Sosyal Medya Linki Boş Geçilemez");
            RuleFor(x => x.Icon).NotEmpty().WithMessage("Sosyal Medya Ikonu Boş Geçilemez");

        }
    }
}
