using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
   public class RentalValidator:AbstractValidator<Rental>
    {
        //Rental sınıfına özel doğrulama kuralları.
        public RentalValidator()
        {
            RuleFor(p => p.RentDate).NotEmpty();
            RuleFor(p => p.ReturnDate).NotEmpty();
        }
    }
}
