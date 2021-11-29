using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class SaleValidator : AbstractValidator<Sale>
    {
        public SaleValidator()
        {
            RuleFor(s => s.Description).MaximumLength(30).WithMessage("Açıklama en fazla 30 karakterden oluşturulmaktadır!");
            RuleFor(s => s.Description).MinimumLength(5).WithMessage("Açıklama en az 5 karakterden oluşturulmaktadır!");
            RuleFor(s => s.PaymentType).NotEmpty().WithMessage("Ödeme Biçimi Boş Geçilemez");
        }
    }
}
