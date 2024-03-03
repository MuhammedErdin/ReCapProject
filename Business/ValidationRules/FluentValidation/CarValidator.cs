using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.CarName).NotEmpty().WithMessage("Araç ismi boş bırakılamaz");
            RuleFor(c => c.CarName).MinimumLength(3).Must(IsLetter).WithMessage(Messages.CarNameMustContainOnlyLetter);
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(0).WithMessage("Günlük tutar 0'dan küçük olamaz");
            RuleFor(c => c.ModelYear).GreaterThanOrEqualTo(1980).WithMessage("1980'den küçük yıl girilemez").LessThanOrEqualTo(DateTime.Now.Day).WithMessage("2024'den büyük yıl girilemez");
            RuleFor(c => c.ColorId).NotEmpty();
            RuleFor(c => c.BrandId).NotEmpty();
            RuleFor(c => c.Descriptions).NotEmpty();
        }

        //Sadece harf içerip içermediğini kontrol eder
        private bool IsLetter(string arg)
        {
            Regex regex = new Regex(@"^[a-zA-ZğüşıöçĞÜŞİÖÇ]+$");
            return regex.IsMatch(arg);
        }
    }
}
