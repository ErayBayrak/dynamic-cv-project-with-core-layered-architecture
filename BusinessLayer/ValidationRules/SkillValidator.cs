using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class SkillValidator:AbstractValidator<Skill>
    {
        public SkillValidator()
        {
            RuleFor(x => x.SkillDescription).NotEmpty().WithMessage("Açıklama Boş Geçilemez");
            RuleFor(x => x.Rate).NotEmpty().WithMessage("Oran Boş Geçilemez");
            RuleFor(x => x.SkillDescription).MaximumLength(1000).WithMessage("Açıklama 1000 Karakteri Geçemez");
            
        }
    }
}
