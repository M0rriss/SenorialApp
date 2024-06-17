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
        public PersonaNaturalResponse PersonaNatural { get; set; } 
        
        public string NombreCompleto 
        {
            
            get
            {
                    if (PersonaNatural == null)
                    {
                        return string.Empty;
                    }

                    var primerNombre = PersonaNatural.PrimerNombre ?? string.Empty;
                    var segundoNombre = PersonaNatural.SegundoNombre ?? string.Empty;

                    return $"{primerNombre} {segundoNombre}";
                
            }
        }
        public string ApellidosCompleto 
        {
            get
            {
                if (PersonaNatural == null)
                {
                    return string.Empty;
                }

                var apellidoPaterno = PersonaNatural.ApellidoPaterno ?? string.Empty;
                var apellidoMaterno = PersonaNatural.ApellidoMaterno ?? string.Empty;

                return $"{apellidoPaterno} {apellidoMaterno}";
            }
        }
    }
}
