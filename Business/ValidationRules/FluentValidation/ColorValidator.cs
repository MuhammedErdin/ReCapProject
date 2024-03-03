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
    public class ColorValidator : AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(c => c.ColorName).NotEmpty();
            RuleFor(c => c.ColorName).Must(IsLetter).WithMessage(Messages.ColorNameMustContainOnlyLetter);
            RuleFor(c => c.ColorName).MinimumLength(2);

        }

        //Sadece harf içerip içermediğini kontrol eder (boşluklu yazım yapılabilir)
        private bool IsLetter(string arg)
        {
            Regex regex = new Regex(@"^[a-zA-ZğüşıöçĞÜŞİÖÇ\s]+$");
            return regex.IsMatch(arg);
        }
    }
}
