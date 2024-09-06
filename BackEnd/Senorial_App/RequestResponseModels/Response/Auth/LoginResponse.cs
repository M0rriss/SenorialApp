using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Auth
{
    public class LoginResponse
    {
        //Campos
        private int _idPersona = 0;
        //private int _idEmpleado = 0;
        private int _idRol = 0;
        private string _nombre = string.Empty;
        private string _email = string.Empty;
        private string _rol = string.Empty;
        //Propiedades 
        public int IdPersona { get => _idPersona; set => _idPersona = value; }
        //public int IdEmpleado { get => _idEmpleado; set => _idEmpleado= value; }
        public int IdRol { get => _idRol; set => _idRol = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Email { get => _email; set => _email = value; }
        public string Rol { get => _rol; set => _rol = value; }
    }
    public class LoginResponseE
    {
        //Campos
        private int _idPersona = 0;
        private int _idEmpleado = 0;
        private int _idRol = 0;
        private string _nombre = string.Empty;
        private string _email = string.Empty;
        private string _rol = string.Empty;
        //Propiedades 
        public int IdPersona { get => _idPersona; set => _idPersona = value; }
        public int IdEmpleado { get => _idEmpleado; set => _idEmpleado = value; }
        public int IdRol { get => _idRol; set => _idRol = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Email { get => _email; set => _email = value; }
        public string Rol { get => _rol; set => _rol = value; }
    }
}
