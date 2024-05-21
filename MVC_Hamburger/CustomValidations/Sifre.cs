using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MVC_Hamburger.CustomValidations
{
    public class Sifre : ValidationAttribute
    {
        private const string DefaultErrorMessage = "Şifre Büyük harf, küçük harf, özel karakter ve rakam içermelidir ve boşluk içermemelidir!";
        public string ErrorMessage { get; set; }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return new ValidationResult(ErrorMessage ?? DefaultErrorMessage);
            }

            string sifre = value.ToString();

            // Şifre kurallarını kontrol eden regex ifadeleri
            bool hasUpperCase = Regex.IsMatch(sifre, @"[A-Z]");
            bool hasLowerCase = Regex.IsMatch(sifre, @"[a-z]");
            bool hasDigit = Regex.IsMatch(sifre, @"\d");
            bool hasSpecialChar = Regex.IsMatch(sifre, @"[!_@#$%^&*(),.?""{}|<>]");
            bool hasNoSpaces = !sifre.Contains(" ");

            if ((hasUpperCase && hasLowerCase && hasDigit && hasSpecialChar && hasNoSpaces)==false)
            {
                return new ValidationResult(ErrorMessage ?? DefaultErrorMessage);
            }
            return ValidationResult.Success;

        }
    }
}

