using IBusiness.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Usuarios.Persona;
using RequestResponseModels.Response.Schema_Usuarios.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Schema_Usuarios.Personas
{
    public interface IPersonaBusiness : ICrudBusiness<PersonaRequest, PersonaResponse>
    {
    }
}
