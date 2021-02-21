using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
   public class ColorValidator:AbstractValidator<Color>
    {
        //Color sınıfına özel doğrulama kuralları.
        public ColorValidator()
        {
            RuleFor(p => p.ColorName).NotEmpty();
            RuleFor(p => p.ColorName).MinimumLength(2);
        }
    }
}
