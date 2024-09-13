using Azure.Core;
using DBSenorialModels.Estados;
using DBSenorialModels.Senorial;
using DBSenorialModels.View.Pedidos;
using IRepository.Schema_Ventas.Pedidos;
using Microsoft.EntityFrameworkCore;
using Repository.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Schema_Ventas.Pedidos
{
    public class PedidoRepository : CrudRepository<Pedido>, IPedidoRepository
    {
        public Task<GenericFilterResponse<Pedido>> GetByFilterAsync(GenericFilterRequest request)
        {
            throw new NotImplementedException();
        }
        public async Task<Pedido> GetPedidoById(int id)
        {
            return await db.Pedidos
                .AsNoTracking()
                .Include(p => p.Detalles)
                .ThenInclude(d => d.Producto)
                .Include(p => p.Mesa)
                .FirstOrDefaultAsync(p => p.IdPedido == id);
                
        }

        public async Task<List<Pedido>> GetAllPedidos()
        {
            return await db.Pedidos
                .Include(p => p.Detalles)
                .ThenInclude(d => d.Producto)
                .Include(p => p.Mesa)
                .ToListAsync();
        }

        public async Task<Pedido> CreatePedido(Pedido pedido)
        {
            db.Pedidos.Add(pedido);
            await db.SaveChangesAsync();
            return pedido;
        }

        public async Task<Pedido> UpdatePedido(Pedido pedido)
        {
            db.Pedidos.Update(pedido);
            await db.SaveChangesAsync();
            return pedido;
           

        }
        public async Task AddDetalle(DetallePedido detalle)
        {
            db.DetallePedidos.Add(detalle);
            await db.SaveChangesAsync();
        }

        public async Task RemoveDetalle(DetallePedido detalle)
        {
            db.DetallePedidos.Remove(detalle);
            await db.SaveChangesAsync();
        }

        public async Task<List<DetallePedido>> GetDetallesByPedidoId(int idPedido)
        {
            return await db.DetallePedidos
                .Where(d => d.IdPedido == idPedido)
                .ToListAsync();
        }
        public async Task UpdateDetalle(DetallePedido detallePedido)
        {
            // Buscar el detalle en la base de datos
            var existingDetalle = await db.DetallePedidos
                .FirstOrDefaultAsync(d => d.IdDetallePedido == detallePedido.IdDetallePedido);

            if (existingDetalle != null)
            {
                // Actualizar los campos del detalle
                existingDetalle.IdProducto = detallePedido.IdProducto;
                existingDetalle.Cantidad = detallePedido.Cantidad;
                existingDetalle.PrecioUnitario = detallePedido.PrecioUnitario;

                // Marcar el contexto como modificado
                db.DetallePedidos.Update(existingDetalle);
                await db.SaveChangesAsync();
            }
        }
        public async Task<bool> DeletePedido(int id)
        {
            var pedido = await db.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return false;
            }

            db.Pedidos.Remove(pedido);
            await db.SaveChangesAsync();
            return true;
        }
        public async Task<List<VwPedido>> ObtenerPedidosAsync()
        {
            var query = await (from p in db.Pedidos
                               join m in db.Mesas on p.IdMesa equals m.IdMesa
                               join e in db.Empleados on p.IdEmpleado equals e.IdEmpleado
                               join ppl in db.Personas on e.IdPersona equals ppl.IdPersona
                               join tp in db.TipoPedidos on p.IdTipoPedido equals tp.IdTipoPedido
                               join dp in db.DetallePedidos on p.IdPedido equals dp.IdPedido
                               group dp by new { p.IdPedido, m.Nombre, ppl.PrimerNombre, tp.Descripcion, p.Estado } into grouped
                               select new VwPedido
                               {
                                   IdPedido = grouped.Key.IdPedido,
                                   NombreMesa = grouped.Key.Nombre,
                                   NombreEmpleado = grouped.Key.PrimerNombre,
                                   TipoPedido = grouped.Key.Descripcion,
                                   CantidadTotal = grouped.Sum(x => x.Cantidad),
                                   Estado = grouped.Key.Estado
                               }).ToListAsync();

            return query;
        }
        public async Task<List<VwDetPedido>> DetallePedidoAsync(int idPedido)
        {
            int x = db.DetallePedidos.Count();
            List<VwDetPedido> query = await (from dp in db.DetallePedidos
                               join p in db.Productos on dp.IdProducto equals p.IdProducto
                               join i in db.Imagenes on p.IdImg equals i.Id
                               where dp.IdPedido == idPedido
                               select new VwDetPedido
                               {
                                   IdPedido = dp.IdPedido,
                                   NombreProducto = p.Nombre,
                                   cantidad = dp.Cantidad,
                                   DescripcionProducto = p.Descripcion, 
                                   PrecioProducto = p.PrecioVenta,
                                   UrlImagen = i.ImageData,
                                   idDetallePedido = dp.IdDetallePedido,
                                   IdProducto = dp.IdProducto,
                               }).ToListAsync();

            return query;
        }

        public async Task<bool> PedidoListoAsync(int idPedido)
        {
            Pedido? query = await (from pedido in dbset
                        where pedido.IdPedido == idPedido
                        select pedido).FirstOrDefaultAsync();

            if(query == null)
            {
                throw new Exception("No se encontro el pedido");
            }
            
            query.Estado = EstadoOrden.Preparado.IdEstadoOrden;

            await Update(query);

            return true;
        }

        public async Task<bool> CancelarPedidoAsync(int idPedido)
        {
            Pedido? query = await (from pedido in dbset
                        where pedido.IdPedido == idPedido
                        select pedido).FirstOrDefaultAsync();

            if(query == null)
            {
                throw new Exception("No se encontro el pedido");
            }
            
            query.Estado = EstadoOrden.Cancelado.IdEstadoOrden;

            await Update(query);

            return true;
        }

    }
}

