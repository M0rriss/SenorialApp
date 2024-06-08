using IBusiness.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Usuarios.PersonaNatural;
using RequestResponseModels.Response.Schema_Usuarios.PersonaNatural;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Schema_Usuarios.PersonaNatural
{
    public interface IPersonaNaturalBusiness : ICrudBusiness<PersonaNaturalRequest, PersonaNaturalResponse>
    {
    }
}
