using System;
using System.Collections.Generic;
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
        public string TipoDocumento { get; set; }
        [Required]
        public string NumeroDocumento { get; set; }
        public string Celular { get; set; }
        [EmailAddress,Required]
        public string Email { get; set; }
        [StrongPassword,Required]
        public string Password { get; set; }
    }
}
