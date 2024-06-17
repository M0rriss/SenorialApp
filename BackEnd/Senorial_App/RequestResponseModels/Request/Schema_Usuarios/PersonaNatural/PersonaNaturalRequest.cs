using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Schema_Usuarios.PersonaNatural
{
    public class PersonaNaturalRequest
    {
        [StringLength(100)]
        public string? PrimerNombre { get; set; }
        [StringLength(100)]
        public string? SegundoNombre { get; set; }
        [StringLength(100)]
        public string? ApellidoPaterno { get; set; }
        [StringLength(100)]
        public string? ApellidoMaterno { get; set; }
        public int IdPersona { get; set; }
        
    }
}
