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
            var query = await (from dp in db.DetallePedidos
                               join p in db.Productos on dp.IdProducto equals p.IdProducto
                               join i in db.Imagenes on p.IdImg equals i.Id
                               where dp.IdPedido == idPedido
                               select new VwDetPedido
                               {
                                   IdPedido = dp.IdPedido,
                                   NombreProducto = p.Nombre,
                                   DescripcionProducto = p.Descripcion, 
                                   PrecioProducto = p.PrecioVenta,
                                   UrlImagen = i.ImageData
                               }).ToListAsync();

            return query;
        }

    }
}

