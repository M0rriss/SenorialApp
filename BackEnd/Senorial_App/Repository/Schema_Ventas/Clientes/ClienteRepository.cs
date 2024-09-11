using DBSenorialModels.Senorial;
using IRepository.Schema_Ventas.Clientes;
using Microsoft.EntityFrameworkCore;
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
        public async Task<Cliente> GetByDocumento(string nroDocumento)
        {
            return await db.Clientes
                .Include(c => c.IdPersonaNavigation) // Incluir la relación con Persona
                .FirstOrDefaultAsync(c => c.IdPersonaNavigation.NroDocumento == nroDocumento);
        }
        public async Task<List<ClienteUiRequest>> UiCliente()
        {
            return await db.Personas.Join(
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
                        IdCliente = pc.p.IdPersona,
                        Nombres = pc.p.PrimerNombre + " " + pc.p.ApellidoPaterno,
                        Correo = pc.p.Email,
                        Telefono = pc.p.Telefono,
                        DNI = pc.p.NroDocumento,
                    }
                    )
                    .ToListAsync();
        }
        public async Task<Cliente> InsertUiCliente(Cliente cliente)
        {
            await dbset.AddAsync(cliente);
            await db.SaveChangesAsync();
            return cliente;
        }
        public async Task<Cliente> UpdateUiCliente(Cliente cliente)
        {
            dbset.Update(cliente);
            await db.SaveChangesAsync();
            return cliente;
        }
        public async Task<bool> DeleteUiCliente(int idCliente)
        {
            // Buscar la persona asociada al cliente
            var cliente = await db.Clientes.FindAsync(idCliente);
            if (cliente == null)
            {
                throw new ArgumentNullException(nameof(cliente), "cliente not found");
            }

            // Eliminar la persona y sus referencias
            db.Remove(cliente);
            await db.SaveChangesAsync();

            // Eliminar cualquier otra referencia o entidad relacionada si es necesario

            return true;
        }
        public Cliente BuscarporId(int id)
        {
            var cliente = dbset.Where(x => x.IdCliente == id).FirstOrDefault();
            return cliente;
        }
        public async Task<Cliente> ObtenerCLientePorId(int id)
        {
            var cliente = dbset.Where(x => x.IdCliente == id).FirstOrDefault();
            return cliente;
        }
    }
}
