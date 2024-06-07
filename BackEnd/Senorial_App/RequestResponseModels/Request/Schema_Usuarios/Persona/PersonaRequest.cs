using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Schema_Usuarios.Persona
{
    public class PersonaRequest
    {
        public int IdPersona { get; set; }
        [StringLength(12)]
        public string? NroDocumento { get; set; }
        [StringLength(50)]
        public string? Correo { get; set; }
        [StringLength(12)]
        public string? Telefono { get; set; }
        [StringLength(100)]
        public string? Direccion { get; set; }
        [StringLength(100)]
        public string TipoDocumento { get; set; } 
        [StringLength(20)]
        public string Genero { get; set; }
        [StringLength(50)]
        public string? TipoPersona { get; set; }
    }
}
