using RequestResponseModels.Response.Schema_Generico.Sucursal;
using RequestResponseModels.Response.Schema_Usuarios.Persona;
using RequestResponseModels.Response.Schema_Ventas.SucursalUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Schema_Ventas.Empleados
{
    public class EmpleadoResponse
    {
        public int IdEmpleado { get; set; }
        public int IdRol { get; set; }
        public int IdPersona { get; set; }
        public int IdSucursal { get; set; }
    }
    public class EmpleadosUiResponse
    {
        public int idEmpleado { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Identificacion { get; set; }
        public string Rol { get; set; }
        public bool Estado { get; set; }
        //public string Sucursal { get; set; } = null;
        public PersonaResponse Persona { get; set; }
        //public SucursalResponse Sucursales { get; set; }

    }
}
