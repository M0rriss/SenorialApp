using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitySecurity.Validations;

namespace RequestResponseModels.Request.Auth
{
    public class SignInEcommerceRequest
    {
        public string Nombres { get; set; } 
        public string Apellidos { get; set; }
        public string TipoDocumento { get; set; } = "DNI";

        [StringLength(8)]
        [DocumentType]

        public string NumeroDocumento { get; set; }
        [StringLength(9)]
        [PhoneValidation]
        public string Celular { get; set; }

        [EmailAddress,Required]
        public string Email { get; set; }
        [StrongPassword,Required]
        [PasswordPropertyText]
        public string Password { get; set; }
    }
}
