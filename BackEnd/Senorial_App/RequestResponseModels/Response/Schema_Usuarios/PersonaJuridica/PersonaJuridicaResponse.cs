using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Schema_Usuarios.PersonaJuridica
{
    public class PersonaJuridicaResponse
    {
        public string? RazonSocial { get; set; }
        public string? NombreComercial { get; set; }
        public int IdPersona { get; set; }
    }
}
