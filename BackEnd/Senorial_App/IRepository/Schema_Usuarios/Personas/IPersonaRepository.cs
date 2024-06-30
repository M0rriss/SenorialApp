using DBSenorialModels.Senorial;
using IRepository.Schema_Generico.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Schema_Usuarios.Personas
{
    public interface IPersonaRepository : ICrudRepository<Persona>
    {
        Task<Persona> BuscarporId(int id);
        Persona BuscarCorreo(string email);
        Persona BuscarDni(string documento);
        Persona BuscarTelefono(string phone);
        Task<bool> DeletePersona(int id);
    }
}
