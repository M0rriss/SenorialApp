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
            return db.Personas.Join(
                   db.Clientes,
                   (p) => p.IdPersona,
                   (c) => c.IdPersona,
                   (p, c) => new ClienteFullRequest
                   {
                       Persona = new PersonaRequest
                       {
                           IdPersona = p.IdPersona,
                           PrimerNombre = p.PrimerNombre,
                           SegundoNombre = p.SegundoNombre,
                           ApellidoMaterno = p.ApellidoMaterno,
                           ApellidoPaterno = p.ApellidoPaterno,
                       },
                       IdCliente = c.IdCliente
                   }
               ).ToList();
        }

        public List<ClienteUiRequest> UiCliente()
        {
            return db.Personas.Join(
                    db.Clientes,
                    p => p.IdPersona,
                    c => c.IdPersona,
                    (p, c) => new { p, c }
    )
                    .Join(
                    db.TipoDocumentos,
                    pc => pc.p.IdTipoDocumento,
                    tp => tp.IdTipoDocumento,
                    (pc, tp) => new ClienteUiRequest
                    {
                        IdCliente = pc.c.IdCliente,
                        Nombres = pc.p.PrimerNombre + " " + pc.p.ApellidoPaterno,
                        Correo = pc.p.Email,
                        Telefono = pc.p.Telefono,
                        DNI = pc.p.NroDocumento,
                    }
                    )
                    .ToList();
        }
    }
}
