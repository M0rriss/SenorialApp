using DBSenorialModels.Senorial;
using DBSenorialModels.View.Mesa;
using IRepository.Schema_Ventas.Mesas;
using Microsoft.EntityFrameworkCore;
using Repository.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Repository.Schema_Ventas.Mesas
{
    public class MesaRepository : CrudRepository<Mesa>, IMesaRepository
    {
        public Task<GenericFilterResponse<Mesa>> GetByFilterAsync(GenericFilterRequest request)
        {
            throw new NotImplementedException();
        }
        public async Task<List<VwMesa>> MesasLocal()
        {
            List<VwMesa> lst = new List<VwMesa>();

            var query = await (from m in db.Mesas
                               join p in db.Pedidos on m.IdMesa equals p.IdMesa into pedidosGroup
                               from p in pedidosGroup.DefaultIfEmpty()
                               join dp in db.DetallePedidos on p.IdPedido equals dp.IdPedido into detallesGroup
                               from dp in detallesGroup.DefaultIfEmpty()
                               group new { p, dp } by new { p.IdPedido, m.IdMesa, m.Nombre, m.EstadoMesaLocal } into grouped
                               select new
                               {
                                   IdPedido = grouped.Key.IdPedido.ToString() ?? "0",
                                   IdMesa = grouped.Key.IdMesa,
                                   NombreMesa = grouped.Key.Nombre,
                                   Precio = grouped.Sum(x => (x.dp != null) ? x.dp.Cantidad * x.dp.PrecioUnitario : 0.00M),
                                   Cantidad = grouped.Sum(x => (x.dp != null) ? x.dp.Cantidad : 0),
                                   EstadoMesaLocal = grouped.Key.EstadoMesaLocal
                               }).ToListAsync();

            lst = query
                .OrderBy(item => int.Parse(new string(item.NombreMesa.Where(char.IsDigit).ToArray()))) // Ordenar por el número en el nombre de la mesa
                .ThenBy(item => item.IdPedido != "0" && !string.IsNullOrEmpty(item.IdPedido))  // Las mesas con IdPedido != "0" o no null al final
                .ToList()
                .Select(item => new VwMesa
                {
                    IdPedido = Convert.ToInt32(item.IdPedido),
                    IdMesa = item.IdMesa,
                    Nombre = item.NombreMesa,
                    Precio = item.Precio,
                    Cantidad = item.Cantidad,
                    Estado = item.EstadoMesaLocal ?? 1,
                })
                .ToList();

            return lst;
        }
        public async Task<List<VwMesaDetalle>> ObtenerDetallesMesaAsync(int idMesa, int idPedido)
        {
            var query = await (from m in db.Mesas
                               join p in db.Pedidos on m.IdMesa equals p.IdMesa
                               join dp in db.DetallePedidos on p.IdPedido equals dp.IdPedido
                               join pd in db.Productos on dp.IdProducto equals pd.IdProducto
                               where m.IdMesa == idMesa && p.IdPedido == idPedido
                               group new { p, m, dp, pd } by new { m.IdMesa, p.IdPedido, pd.Nombre, dp.PrecioUnitario } into grouped
                               select new VwMesaDetalle
                               {
                                   IdPedidoMesa = grouped.Key.IdPedido,
                                   IdMesaDetalle = grouped.Key.IdMesa,
                                   NombreProducto = grouped.Key.Nombre,
                                   CantidadItems = grouped.Sum(x => x.dp.Cantidad),
                                   SubTotal = grouped.Sum(x => x.dp.Cantidad * x.dp.PrecioUnitario)
                               }).ToListAsync();

            return query;
        }

        public async Task<Mesa> GetMesaByIdAsync(int idMesa)
        {
            return await db.Mesas.FindAsync(idMesa);
        }

        public async Task UpdateMesaAsync(Mesa mesa)
        {
            db.Mesas.Update(mesa);
            await db.SaveChangesAsync();
        }




    }
}
