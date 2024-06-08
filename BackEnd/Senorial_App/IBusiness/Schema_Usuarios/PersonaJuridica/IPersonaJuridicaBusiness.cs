using IBusiness.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Usuarios.PersonaJuridica;
using RequestResponseModels.Response.Schema_Usuarios.PersonaJuridica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Schema_Usuarios.PersonaJuridica
{
    public interface IPersonaJuridicaBusiness : ICrudBusiness<PersonaJuridicaRequest, PersonaJuridicaResponse>
    {
    }
}
