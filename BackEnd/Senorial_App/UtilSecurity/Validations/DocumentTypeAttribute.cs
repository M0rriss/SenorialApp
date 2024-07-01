using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitySecurity.Validations
{
    public class DocumentTypeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext context)
        {
            if (value == null || !(value is string))
            {
                return new ValidationResult("El tipo de documento no puede ser nulo");
            }

            string documentType = value as string;

            if (string.IsNullOrWhiteSpace(documentType))
            {
                return new ValidationResult("El tipo de documento no puede estar vacío");
            }

            if (documentType.Length < 8 || documentType.Length > 12)
            {
                return new ValidationResult("El tipo de documento debe tener entre 8 y 12 caracteres numéricos");
            }

            foreach (char c in documentType)
            {
                if (!char.IsDigit(c))
                {
                    return new ValidationResult("El tipo de documento debe contener solo números");
                }
            }

            return ValidationResult.Success;
        }
    }
}
