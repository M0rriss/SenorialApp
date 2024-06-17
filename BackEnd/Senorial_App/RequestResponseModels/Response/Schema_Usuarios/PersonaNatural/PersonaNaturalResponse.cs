using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Schema_Usuarios.PersonaNatural
{
    public class PersonaNaturalResponse
    {
        public string? PrimerNombre { get; set; }
        public string? SegundoNombre { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public int IdPersona { get; set; }
        public string NombresCompletos
        {
            get
            {
                return $"{PrimerNombre} {SegundoNombre} {ApellidoPaterno} {ApellidoMaterno}".Trim();
            }
        }
    }
}
