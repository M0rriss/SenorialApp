using DBSenorialModels.Senorial;
using IRepository.Schema_Usuarios.Personas;
using Microsoft.EntityFrameworkCore;
using Repository.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Schema_Usuarios.Personas
{
    public class PersonaRepository : CrudRepository<Persona>, IPersonaRepository
    {
        public Task<GenericFilterResponse<Persona>> GetByFilterAsync(GenericFilterRequest request)
        {
            throw new NotImplementedException();
        }
        public async Task<Persona> BuscarporId(int id)
        {
            var persona = dbset.Where(x => x.IdPersona == id).FirstOrDefault();
            return persona;
        }
        public async  Task<Persona> BuscarCorreo(string email)
        {
            var persona = await dbset.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefaultAsync();
            return persona;
        }
        public  async Task<Persona> BuscarDni(string documento)
        {
            var persona = dbset.Where(x => x.NroDocumento == documento).FirstOrDefault();
            return persona;
        }
        public async Task<Persona> BuscarTelefono(string phone)
        {
            var persona = dbset.Where(x => x.Telefono == phone).FirstOrDefault();
            return persona;
        }
        public async Task<bool> DeletePersona(int id)
        {
            var entity = await dbset.FindAsync(id);
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Person not found");
            }

            dbset.Remove(entity);
            await db.SaveChangesAsync();
            return true;
        }
    }
}
