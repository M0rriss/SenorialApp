using RequestResponseModels.Response.Schema_Usuarios.Persona;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Schema_Almacen.Proveedor
{
    public class ProveedorResponse
    {
        public int IdProveedor { get; set; }
        public int IdPersona { get; set; }
        public string? Vende { get; set; }
    }
    public class ProveedorUiResponse
    {
        public string ProveedorNombre { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Dni { get; set; }
        public string Distribuye { get; set; }
        public PersonaResponse Persona { get; set; }
    }
}
