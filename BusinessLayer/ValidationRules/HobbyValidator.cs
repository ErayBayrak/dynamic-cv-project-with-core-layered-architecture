using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class HobbyValidator:AbstractValidator<Hobby>
    {
        public HobbyValidator()
        {
            RuleFor(x => x.Description1).NotEmpty().WithMessage("Açıklama Boş Geçilemez.");
            RuleFor(x => x.Description2).NotEmpty().WithMessage("Açıklama Boş Geçilemez.");
        }
    }
}
