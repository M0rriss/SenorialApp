using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RequestResponseModels.Request.Schema_Usuarios.Persona;
using UtilitySecurity.Validations;

namespace RequestResponseModels.Request.Schema_Ventas.Cliente
{
    public class ClienteRequest
    {
        public int IdCliente { get; set; }
        public int IdPersona { get; set; }
    }
    
    public class ClienteUiRequest
    {
        public int IdCliente { get; set; }
        public string Nombres { get; set; }
        [EmailAddress]
        public string Correo { get; set; }
        [Phone]
        public string Telefono { get; set; }
        [DocumentType]
        public string DNI { get; set; }
    }
    public class ClienteMovilRequest
    {
        public int IdCliente { get; set; }
        public string Nombres { get; set; }
        
        [Phone]
        public string? Telefono { get; set; }
        [DocumentType]
        public string NroDocumento { get; set; }

    }
    public class ClienteUpdateUiRequest
    {
        public int IdCliente { get; set; }
        public string Nombres { get; set; }
        [EmailAddress]
        public string Correo { get; set; }
        [Phone]
        public string Telefono { get; set; }
        [DocumentType]
        public string DNI { get; set; }
    }
}
//SELECT Concat(p.primer_nombre, p.apellido_paterno) as Nombres,
//p.email as Correo,p.telefono AS Celular, p.nro_Documento AS DNI FROM
//Usuarios.personas p Inner Join Ventas.cliente c ON p.id_persona = id_cliente;