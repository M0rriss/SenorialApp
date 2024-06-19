using RequestResponseModels.Response.Schema_Usuarios.Persona;
using RequestResponseModels.Response.Schema_Usuarios.PersonaNatural;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Auth
{
    public class SignInEcommerceResponse
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        //public string Celular { get; set; }
        public PersonaResponse Persona { get; set; } 
        
        public string NombreCompleto 
        {
            
            get
            {
                    if (Persona == null)
                    {
                        return string.Empty;
                    }

                    var primerNombre = Persona.PrimerNombre ?? string.Empty;
                    var segundoNombre = Persona.SegundoNombre ?? string.Empty;

                    return $"{primerNombre} {segundoNombre}";
                
            }
        }
        public string ApellidosCompleto 
        {
            get
            {
                if (Persona == null)
                {
                    return string.Empty;
                }

                var apellidoPaterno = Persona.ApellidoPaterno ?? string.Empty;
                var apellidoMaterno = Persona.ApellidoMaterno ?? string.Empty;

                return $"{apellidoPaterno} {apellidoMaterno}";
            }
        }
    }
}
