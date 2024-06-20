using DBSenorialModels.Senorial;
using IRepository.Schema_Ventas.Clientes;
using Repository.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Request.Schema_Usuarios.Persona;
using RequestResponseModels.Request.Schema_Ventas.Cliente;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Schema_Ventas.Clientes
{
    public class ClienteRepository : CrudRepository<Cliente>, IClienteRepository
    {
        
        public Task<GenericFilterResponse<Cliente>> GetByFilterAsync(GenericFilterRequest request)
        {
            throw new NotImplementedException();
        }

        public List<ClienteFullRequest> GetFull()
        {
             return this.db.Personas.Join(
                this.db.Clientes,
                (p)=>p.IdPersona,
                (c)=>c.IdPersona,
                (p,c) => new ClienteFullRequest { Persona = new PersonaRequest{
                    IdPersona = p.IdPersona,
                    PrimerNombre = p.PrimerNombre,
                    SegundoNombre = p.SegundoNombre,
                    ApellidoMaterno = p.ApellidoMaterno,
                    ApellidoPaterno = p.ApellidoPaterno,
                }, IdCliente = c.IdCliente}
                ).ToList();
        }
    }
}
