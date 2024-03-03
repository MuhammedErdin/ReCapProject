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
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(r => r.FirstName).NotEmpty();
            RuleFor(r => r.FirstName).MinimumLength(4);
            RuleFor(r => r.FirstName).Must(IsContainLetter).WithMessage(Messages.FirstNameMustContainOnlyLetter);
            RuleFor(r => r.LastName).NotEmpty();
            RuleFor(r => r.LastName).MinimumLength(4);
            RuleFor(r => r.LastName).Must(IsContainLetter).WithMessage(Messages.LastNameMustContainOnlyLetter);
            RuleFor(r => r.Email).NotEmpty();
            RuleFor(r => r.Email).EmailAddress();
            RuleFor(r => r.PasswordHash).NotEmpty();
            RuleFor(r => r.PasswordHash).MinimumLength(8);
            RuleFor(r => r.PasswordHash).Must(IsContainLetter).WithMessage("Karakter").Must(IsContainDigit).WithMessage("Sayı").Must(IsContainSpecialCharacter).WithMessage("Özel karakter");
        }

        //En az bir harf olup olmadığını kontrol eder
        private bool IsContainLetter(string arg)
        {
            return arg.Any(char.IsLetter);
        }

        //En az bir sayı olup olmadığını kontrol eder
        private bool IsContainDigit(string arg)
        {
            return arg.Any(char.IsDigit);
        }

        //En az bir özel karakter olup olmadığını kontrol eder
        private bool IsContainSpecialCharacter(string arg)
        {
            char[] specialCharacters = { '@', '#', '$', '!', '.', ',', '*', '-', '_', ';', '+', '-', '<', '>' };
            return arg.Any(c => specialCharacters.Contains(c));
        }
    }
}
