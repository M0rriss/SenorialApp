using RequestResponseModels.Response.Schema_Usuarios.PersonaNatural;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Auth
{
    public class SignInMobileResponse
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Dni { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public PersonaNaturalResponse PersonaNatural { get; set; } = new PersonaNaturalResponse();
        //public string NombresCompletos
        //{
        //    get
        //    {
        //        return $"{PersonaNatural.PrimerNombre} {PersonaNatural.SegundoNombre} {PersonaNatural.ApellidoPaterno} {PersonaNatural.ApellidoMaterno}".Trim();
        //    }
        //}

    }
}
