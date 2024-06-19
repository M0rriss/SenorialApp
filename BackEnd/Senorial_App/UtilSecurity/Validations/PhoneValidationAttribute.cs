using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitySecurity.Validations
{
    public class PhoneValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || !(value is string))
            {
                return new ValidationResult("El número de teléfono no puede ser nulo");
            }

            string phoneNumber = value as string;

            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                return new ValidationResult("El número de teléfono no puede estar vacío");
            }

            if (phoneNumber.Length != 9)
            {
                return new ValidationResult("El número de teléfono debe tener exactamente 9 dígitos");
            }

            if (phoneNumber[0] != '9')
            {
                return new ValidationResult("El número de teléfono debe comenzar con '9'");
            }

            foreach (char c in phoneNumber)
            {
                if (!char.IsDigit(c))
                {
                    return new ValidationResult("El número de teléfono debe contener solo dígitos");
                }
            }

            return ValidationResult.Success;
        }
    }
}
