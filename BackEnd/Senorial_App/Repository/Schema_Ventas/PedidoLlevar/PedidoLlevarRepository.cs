using DBSenorialModels.Estados;
using DBSenorialModels.Senorial;
using DBSenorialModels.View.PedidosLlevar;
using IRepository.Schema_Ventas.PedioLlevar;
using Microsoft.EntityFrameworkCore;
using Repository.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Schema_Ventas.TbPedidoLlevar
{
    public class PedidoLlevarRepository : CrudRepository<PedidoLlevar>, IPedidoLlevarRepository
    {
        public Task<GenericFilterResponse<PedidoLlevar>> GetByFilterAsync(GenericFilterRequest request)
        {
            throw new NotImplementedException();
        }
        // Obtener un pedido para llevar por ID
        public async Task<PedidoLlevar> GetPedidoLlevarById(int id)
        {
            return await db.PedidosLlevar
                
                .Include(p => p.DetallesLlevar)
                .ThenInclude(d => d.Producto)
                .FirstOrDefaultAsync(p => p.IdPedidoLlevar == id);
        }

        // Obtener todos los pedidos para llevar
        public async Task<List<PedidoLlevar>> GetAllPedidosLlevar()
        {
            return await db.PedidosLlevar
                .Include(p => p.DetallesLlevar) 
                .ThenInclude(d => d.Producto) 
                .ToListAsync();
        }

        // Crear un nuevo pedido para llevar
        public async Task<PedidoLlevar> CreatePedidoLlevar(PedidoLlevar pedidoLlevar)
        {
            db.PedidosLlevar.Add(pedidoLlevar);
            await db.SaveChangesAsync();
            return pedidoLlevar;
        }

        // Actualizar un pedido para llevar existente
        public async Task<PedidoLlevar> UpdatePedidoLlevar(PedidoLlevar pedidoLlevar)
        {
            db.PedidosLlevar.Update(pedidoLlevar);
            await db.SaveChangesAsync();
            return pedidoLlevar;
        }

        // Eliminar un pedido para llevar por ID
        public async Task<bool> DeletePedidoLlevar(int id)
        {
            var pedidoLlevar = await db.PedidosLlevar.FindAsync(id);
            if (pedidoLlevar == null)
            {
                return false;
            }

            db.PedidosLlevar.Remove(pedidoLlevar);
            await db.SaveChangesAsync();
            return true;
        }
        public async Task<List<VwPedidoLlevar>> ObtenerPedidosLlevarAsync()
        {
            var query = await (from pl in db.PedidosLlevar
                       join c in db.Clientes on pl.IdCliente equals c.IdCliente
                       join e in db.Empleados on pl.IdEmpleado equals e.IdEmpleado
                       join ppl in db.Personas on c.IdPersona equals ppl.IdPersona
                       join tp in db.TipoPedidos on pl.IdTipoPedido equals tp.IdTipoPedido
                       join dp in db.DetallePedidosLlevar on pl.IdPedidoLlevar equals dp.IdPedidoLlevar
                       group dp by new { pl.IdPedidoLlevar, ppl.PrimerNombre, ppl.SegundoNombre, ppl.ApellidoPaterno, ppl.ApellidoMaterno, tp.Descripcion, pl.Estado } into grouped
                       select new VwPedidoLlevar
                       {
                           IdPedidoLlevar = grouped.Key.IdPedidoLlevar,
                           NombresCompletosCliente = grouped.Key.PrimerNombre + " " + grouped.Key.SegundoNombre + " " + grouped.Key.ApellidoPaterno + " " + grouped.Key.ApellidoMaterno,
                           NombreEmpleado = grouped.Key.PrimerNombre, 
                           TipoPedido = grouped.Key.Descripcion,
                           CantidadTotal = grouped.Sum(x => x.Cantidad),
                           Estado = grouped.Key.Estado
                       }).ToListAsync();

             return query;
        }
        public async Task<List<VwDetPedidoLlevar>> DetallePedidoLlevarAsync(int idPedidoLlevar)
        {
            List<VwDetPedidoLlevar> query = await (from dp in db.DetallePedidosLlevar
                                                   join p in db.Productos on dp.IdProducto equals p.IdProducto
                                                   join i in db.Imagenes on p.IdImg equals i.Id
                                                   where dp.IdPedidoLlevar == idPedidoLlevar
                                                   select new VwDetPedidoLlevar
                                                   {
                                                       IdPedidoLlevar = dp.IdPedidoLlevar,
                                                       NombreProducto = p.Nombre,
                                                       DescripcionProducto = p.Descripcion,
                                                       PrecioProducto = p.PrecioVenta,
                                                       UrlImagen = i.ImageData
                                                   }).ToListAsync();

            return query;
        }
        public async Task<bool> PedidoListoAsync(int idPedidoLlevar)
        {
            PedidoLlevar? query = await (from pedido in dbset
                                   where pedido.IdPedidoLlevar == idPedidoLlevar
                                         select pedido).FirstOrDefaultAsync();

            if (query == null)
            {
                throw new Exception("No se encontro el pedido");
            }

            query.Estado = EstadoOrden.Preparado.IdEstadoOrden;

            await Update(query);

            return true;
        }

        public async Task<bool> CancelarPedidoAsync(int idPedidoLlevar)
        {
            PedidoLlevar? query = await (from pedido in dbset
                                   where pedido.IdPedidoLlevar == idPedidoLlevar
                                         select pedido).FirstOrDefaultAsync();

            if (query == null)
            {
                throw new Exception("No se encontro el pedido");
            }

            query.Estado = EstadoOrden.Cancelado.IdEstadoOrden;

            await Update(query);

            return true;
        }

    }
    
}
