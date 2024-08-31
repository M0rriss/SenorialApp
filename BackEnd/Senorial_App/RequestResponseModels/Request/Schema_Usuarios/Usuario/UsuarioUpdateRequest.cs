using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Schema_Usuarios.Usuario
{
    public class UsuarioUpdateRequest
    {
        private int _idUsuario = 0;
        private IFormFile? _file = null!;
        private string _email = string.Empty;
        private string _password = string.Empty;
        private int _role = 0;
        private string _contact = string.Empty;
        private string _nombreCompleto = string.Empty;

        public int IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public IFormFile? File { get => _file; set => _file = value; }
        public string Email { get => _email; set => _email = value; }
        public string Password { get => _password; set => _password = value; }
        public int Role { get => _role; set => _role = value; }
        public string Contact { get => _contact; set => _contact = value; }
        public bool Nuevo { get; set; } = false;
        public string NombreCompleto { get => _nombreCompleto; set => _nombreCompleto = value; }
    }
}
