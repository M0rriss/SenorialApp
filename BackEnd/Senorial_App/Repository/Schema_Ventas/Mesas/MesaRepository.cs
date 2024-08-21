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

            List<VwMesa> lst = [];
            var query = await (from m in db.Mesas
                               join p in db.Pedidos on m.IdMesa equals p.IdMesa into pedidosGroup
                               from p in pedidosGroup.DefaultIfEmpty()
                               join dp in db.DetallePedidos on p.IdPedido equals dp.IdPedido into detallesGroup
                               from dp in detallesGroup.DefaultIfEmpty()
                               group new { p, dp } by new { p.IdPedido, m.Nombre, m.Estado } into grouped
                               select new
                               {
                                   IdPedido = grouped.Key.IdPedido.ToString() ?? "0",
                                   NombreMesa = grouped.Key.Nombre,
                                   Precio = grouped.Sum(x => (x.dp != null) ? x.dp.Cantidad * x.dp.PrecioUnitario : 0.00M),
                                   Cantidad = grouped.Sum(x => (x.dp != null) ? x.dp.Cantidad : 0),
                                   EstadoMesa = grouped.Key.Estado
                               }).ToListAsync();

            lst = query.Select(item => new VwMesa
            {
                IdPedido = Convert.ToInt32(item.IdPedido),
                Nombre = item.NombreMesa,
                Precio = item.Precio,
                Cantidad = item.Cantidad,
                Estado = item.EstadoMesa
            }).ToList();
            return lst;
        }
        public async Task<List<VwMesaDetalle>> ObtenerDetallesDeMesasAsync()
        {
            var query = await (from m in db.Mesas
                               join p in db.Pedidos on m.IdMesa equals p.IdMesa
                               join dp in db.DetallePedidos on p.IdPedido equals dp.IdPedido
                               join pd in db.Productos on dp.IdProducto equals pd.IdProducto
                               group new { m, dp, pd } by new { m.IdMesa, NombreMesa = m.Nombre, NombreProducto = pd.Nombre, dp.PrecioUnitario } into grouped
                               select new VwMesaDetalle
                               {
                                   IdMesaDetalle = grouped.Key.IdMesa,
                                   NombreMesa = grouped.Key.NombreMesa,  // Usamos NombreMesa
                                   NombreProducto = grouped.Key.NombreProducto,  // Usamos NombreProducto
                                   CantidadItems = grouped.Sum(x => x.dp.Cantidad),
                                   PrecioUnitario = grouped.Key.PrecioUnitario,
                                   SubTotal = grouped.Sum(x => x.dp.Cantidad * x.dp.PrecioUnitario),
                                   Total = grouped.Sum(x => x.dp.Cantidad * x.dp.PrecioUnitario) // Este cálculo será por mesa
                               }).ToListAsync();

            // Cálculo del total por mesa
            var mesasConTotal = query.GroupBy(q => q.IdMesaDetalle)
                                     .SelectMany(group => group.Select(mesaDetalle => new VwMesaDetalle
                                     {
                                         IdMesaDetalle = mesaDetalle.IdMesaDetalle,
                                         NombreMesa = mesaDetalle.NombreMesa,
                                         NombreProducto = mesaDetalle.NombreProducto,
                                         CantidadItems = mesaDetalle.CantidadItems,
                                         PrecioUnitario = mesaDetalle.PrecioUnitario,
                                         SubTotal = mesaDetalle.SubTotal,
                                         Total = group.Sum(x => x.SubTotal) // Agrupamos por mesa para calcular el total
                                     })).ToList();

            return mesasConTotal;
        }





    }
}
