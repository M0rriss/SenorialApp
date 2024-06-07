using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Schema_Usuarios.PersonaJuridica
{
    public class PersonaJuridicaRequest
    {
        [StringLength(100)]
        public string? RazonSocial { get; set; }
        [StringLength(100)]
        public string? NombreComercial { get; set; }
        public int IdPersona { get; set; }
    }
}
