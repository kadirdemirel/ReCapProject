using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
   public class CustomerValidator:AbstractValidator<Customer>
    {
        //Customer sınıfına özel doğrulama kuralları.
        public CustomerValidator()
        {
            RuleFor(p => p.CompanyName).NotEmpty();
        }
    }
}
