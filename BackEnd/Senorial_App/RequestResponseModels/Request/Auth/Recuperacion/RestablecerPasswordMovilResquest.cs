using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitySecurity.Validations;

namespace RequestResponseModels.Request.Auth.Recuperacion
{
    public class RestablecerPasswordMovilRequest
    {
        [EmailAddress, Required]
        public string Email { get; set; }
        [Required]
        public string CodigoOtp { get; set; }
        [Required,StrongPassword,PasswordPropertyText]
        public string NuevoPassword { get; set; }
        [Required, StrongPassword, PasswordPropertyText]
        public string ConfirmarContraseña { get; set; }
    }
}
