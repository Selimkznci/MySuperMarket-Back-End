using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).MinimumLength(2).WithMessage("Ürün ismi en az 2 Karakterden oluşturulmalıdır");
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("Ürün ismi Boş Geçilemez!");
            RuleFor(p => p.UnitPrice).NotEmpty().WithMessage("Birim Fiyat Boş Geçilemez!");
            RuleFor(p => p.UnitPrice).GreaterThan(0).WithMessage("Birim Fiyat 0 Olamaz!");
            RuleFor(p => p.UnitsInStocks).NotEmpty().WithMessage("Stok Durumu Boş Olamaz!");
        }
    }
 }
