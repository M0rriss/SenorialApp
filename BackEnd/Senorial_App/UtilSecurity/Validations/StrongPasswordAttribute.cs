using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitySecurity.Validations
{
    public class StrongPasswordAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext context)
        {

            string password = value?.ToString() ?? string.Empty;

            if (password == "")
            {
                return new ValidationResult("La contraseña no puede ser vacio");
            }
            if (password.Length < 8)
            {
                return new ValidationResult("La contraseña no puede tener menos de 8 caracteres");
            }
            if (!password.Any(char.IsUpper))
            {
                return new ValidationResult("La contraseña debe contener por lo menos una mayuscular");

            }
            if (!password.Any(char.IsLower))
            {
                return new ValidationResult("La contraseña debe contener por lo menos una minuscula");

            }
            if (!password.Any(char.IsNumber))
            {
                return new ValidationResult("La contraseña debe contener por lo menos un numero");

            }


            return ValidationResult.Success;
        }
    }
}
