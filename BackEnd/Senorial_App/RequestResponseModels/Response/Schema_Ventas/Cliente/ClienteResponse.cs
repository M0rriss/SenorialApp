using RequestResponseModels.Response.Schema_Usuarios.Persona;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitySecurity.Validations;

namespace RequestResponseModels.Response.Schema_Ventas.Cliente
{
    public class ClienteResponse
    {
        public int IdCliente { get; set; }
        public int IdPersona { get; set; }
    }
    public class ClienteUiResponse 
    { 
        public int idCliente {  get; set; }
        public string Nombres { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string DNI { get; set; }
        public PersonaResponse Persona { get; set; }
    }
    
}
