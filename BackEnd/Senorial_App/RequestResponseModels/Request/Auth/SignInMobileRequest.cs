using RequestResponseModels.Response.Schema_Usuarios.PersonaNatural;
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
    public class SignInMobileRequest
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string TipoDoc { get; set; } = "DNI";
        public string Dni { get; set; }
        [StringLength(9)]
        [PhoneValidation]
        public string Telefono { get; set; }
        [EmailAddress,Required]
        public string Email { get; set; }
        [StrongPassword,Required, PasswordPropertyText]
        public string Password { get; set; }
        [StrongPassword,Required, PasswordPropertyText]
        public string ConfirmarPassword { get; set; }

        //public PersonaNaturalResponse PersonaNatural { get; set; } = new PersonaNaturalResponse();
    }
}
