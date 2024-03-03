using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.CustomerId).NotEmpty();
            RuleFor(r => r.CarId).NotEmpty();
            RuleFor(r => r.RentDate).NotEmpty();
            RuleFor(r => r.RentDate).Must(BeValidDateFormat);
        }

        private bool BeValidDateFormat(DateTime rentDate)
        {
            return DateTime.TryParseExact(rentDate.ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
            //Bu satır, rentDate'in "yyyy-MM-dd" formatında olup olmadığını kontrol eder. DateTime.TryParseExact metodunu kullanarak rentDate'i belirli bir formatta çözümleyerek kontrol eder.
        }
    }
}
