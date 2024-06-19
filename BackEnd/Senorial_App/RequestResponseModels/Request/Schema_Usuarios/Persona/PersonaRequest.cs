using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RequestResponseModels.Response.Schema_Usuarios.Persona;
using UtilitySecurity.Validations;

namespace RequestResponseModels.Request.Schema_Usuarios.Persona
{
    public class PersonaRequest
    {
        public int IdPersona { get; set; }
        [StringLength(100)]
        public string? PrimerNombre { get; set; }
        [StringLength(100)]
        public string? SegundoNombre { get; set; }
        [StringLength(100)]
        public string? ApellidoPaterno { get; set; }
        [StringLength(100)]
        public string? ApellidoMaterno { get; set; }
        [StringLength(12, MinimumLength = 12)]
        [DocumentType]
        public string? NroDocumento { get; set; }
        [StringLength(50),EmailAddress]
        public string? Email { get; set; }
        [StringLength(9, MinimumLength = 9)]
        [PhoneValidation]
        public string? Telefono { get; set; }
        [StringLength(100)]
        public string? Direccion { get; set; }
        [StringLength(100)]
        public string TipoDocumento { get; set; } = null!;
        [StringLength(50)]
        public string? TipoPersona { get; set; }
        [StringLength(100)]
        public string? RazonSocial { get; set; }
        [StringLength(20)]
        public string Genero { get; set; } = null!;
        //public PersonaResponse Persona { get; set; }
        //public string NombreCompleto
        //{

        //    get
        //    {
        //        if (Persona == null)
        //        {
        //            return string.Empty;
        //        }

        //        var primerNombre = Persona.PrimerNombre ?? string.Empty;
        //        var segundoNombre = Persona.SegundoNombre ?? string.Empty;

        //        return $"{primerNombre} {segundoNombre}";

        //    }
        //}
        //public string ApellidosCompleto
        //{
        //    get
        //    {
        //        if (Persona == null)
        //        {
        //            return string.Empty;
        //        }

        //        var apellidoPaterno = Persona.ApellidoPaterno ?? string.Empty;
        //        var apellidoMaterno = Persona.ApellidoMaterno ?? string.Empty;

        //        return $"{apellidoPaterno} {apellidoMaterno}";
        //    }
        //}
    }
}
