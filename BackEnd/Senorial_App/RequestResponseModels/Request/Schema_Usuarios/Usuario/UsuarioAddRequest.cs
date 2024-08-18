using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitySecurity.Validations;

namespace RequestResponseModels.Request.Schema_Usuarios.Usuario
{
    public class UsuarioAddRequest
    {
        private IFormFile _file = null!;
        private string _email = string.Empty;
        private string _password = string.Empty;
        private int _role = 0;
        private string _contact = string.Empty;

        public IFormFile File { get => _file; set => _file = value; }
        [EmailAddress]
        public string Email { get => _email; set => _email = value; }
        [StrongPassword]
        public string Password { get => _password; set => _password = value; }
        [Required]
        public int Role { get => _role; set => _role = value; }
        [Required]
        public string Contact { get => _contact; set => _contact = value; }
    }
}
