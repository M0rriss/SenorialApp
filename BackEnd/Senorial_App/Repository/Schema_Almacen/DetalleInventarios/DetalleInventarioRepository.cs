using DBSenorialModels.Estados;
using DBSenorialModels.Senorial;
using DBSenorialModels.View.Almacen;
using DBSenorialModels.View.Almacen.DetalleIngreso;
using IRepository.Schema_Almacen.DetalleInventarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Repository.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Schema_Almacen.DetalleInventarios
{
    public class DetalleInventarioRepository : CrudRepository<DetalleInventario>, IDetalleInventarioRepository
    {
        public Task<GenericFilterResponse<DetalleInventario>> GetByFilterAsync(GenericFilterRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<GenericFilterResponse<VwDetalleIngreos>> ListardetalleInventarioAsync(int page, int pagesize, string insumo)
        {
            var entradas = from di in db.DetalleInventarios
                           join e in db.Entradas on di.IdInsumo equals e.IdInsumo
                           join i in db.Insumos on e.IdInsumo equals i.IdInsumo
                           join u in db.UnidadMedicions on i.IdUnidad equals u.IdUnidad
                           select new
                           {
                               IdInventario = di.IdInventario,
                               Insumo = i.Nombre,
                               Stock = e.Cantidad,
                               Fecha = e.FechaIngreso,
                               UnidadMedida = u.Descripcion,
                               Tipo = "Entradas"
                           };

            var salidas = from di in db.DetalleInventarios
                          join s in db.Salidas on di.IdInsumo equals s.IdInsumo
                          join i in db.Insumos on s.IdInsumo equals i.IdInsumo
                          join u in db.UnidadMedicions on i.IdUnidad equals u.IdUnidad
                          select new
                          {
                              IdInventario = di.IdInventario,
                              Insumo = i.Nombre,
                              Stock = s.Cantidad,
                              Fecha = s.FechaSalida,
                              UnidadMedida = u.Descripcion,
                              Tipo = "Salidas"
                          };
            List<VwDetalleIngreos> result = await entradas.Union(salidas)
                    .Select(x => new VwDetalleIngreos()
                    {
                        idInventario = x.IdInventario,
                        Insumo = x.Insumo,
                        Fecha = x.Fecha,
                        Stock = x.Stock,
                        Tipo = x.Tipo,
                        UnidadMedida = x.UnidadMedida
                    }).ToListAsync();
            if (!insumo.IsNullOrEmpty())
            {
                 result = result.Where(x => x.Insumo.ToLower().Contains(insumo.ToLower())).ToList();
            }
            GenericFilterResponse<VwDetalleIngreos> lst = new();
            lst.TotalRegistros = result.Count();
            lst.Lista = result.OrderByDescending(x => x.Fecha).Skip((page - 1) * pagesize).Take(pagesize).ToList();
            return lst;
        }

        public async Task<VwBuscarInsumoDetalle> BuscarInsumoAsync(int idInsumo)
        {
            VwBuscarInsumoDetalle? query = await (
                from inventario in dbset
                join insumo in db.Insumos
                    on inventario.IdInsumo equals insumo.IdInsumo
                        where inventario.IdInsumo == idInsumo
                        select new VwBuscarInsumoDetalle
                        {
                            IdInsumo = idInsumo,
                            IdInventario = inventario.IdInventario,
                            Nombre  = insumo.Nombre,
                            StockTotal = inventario.StockTotal,
                        }  ).FirstOrDefaultAsync();
            if(query == null)
            {
                throw new Exception("No se encontro suministro");
            }
            return query;
        }

        public async Task<GenericFilterResponse<VwDetalleInsumos>> ListarDetalleInventario(int page, int pagesize, string insumo)
        {
            List<VwDetalleInsumos> query = await (from detalle in dbset
                        join insumos in db.Insumos
                            on detalle.IdInsumo equals insumos.IdInsumo
                        where detalle.IdEstado == Estado.Activo.IdEstado
                        select new VwDetalleInsumos
                        {
                            IdInsumo = detalle.IdInsumo,
                            Disponibilidad = detalle.StockTotal >= 2 && detalle.StockTotal <= 10 ? "Agotandose" :
                                           detalle.StockTotal >= 11 && detalle.StockTotal <= 18 ? "En Proceso" :
                                           "Disponible",
                            IdInventario = detalle.IdInventario,
                            Nombre = insumos.Nombre,
                            Stoct = detalle.StockTotal
                        }).ToListAsync();
            if (!insumo.IsNullOrEmpty())
            {
                query = query
                .Where(x => x.Nombre.ToLower().Contains(insumo.ToLower())).ToList();
            }

            GenericFilterResponse<VwDetalleInsumos> lst = new();
            lst.TotalRegistros = query.Count();
            lst.Lista = query.Skip((page - 1) * pagesize).Take(pagesize).ToList();

            
            
            return lst;
        }

        public async Task<bool> EliminarInsumoAsync(int idInsumo)
        {
            DetalleInventario? query = await (from detalle in dbset
                         where detalle.IdInsumo == idInsumo
                         select detalle).FirstOrDefaultAsync();
            if(query == null)
            {
                throw new Exception("No se encontro el suministro");
            }
            query.IdEstado = Estado.Inactivo.IdEstado;
            await Update(query);
            return true;
        }
    }
}
