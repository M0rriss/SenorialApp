using DBSenorialModels.Senorial;
using DBSenorialModels.View.Producto;
using IRepository.Schema_Almacen.Insumos;
using Microsoft.EntityFrameworkCore;
using Repository.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Almacen.Insumo;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Almacen.Insumo;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Schema_Almacen.Insumos
{
    public class InsumoRepository : CrudRepository<Insumo>, IInsumoRepository
    {
        public Task<GenericFilterResponse<Insumo>> GetByFilterAsync(GenericFilterRequest request)
        {
            throw new NotImplementedException();
        }
        public async Task<List<InsumoUiRequest>> UiInsumo()
        {
            return await db.Insumos.Join(
                    db.UnidadMedicions,
                    i => i.IdUnidad,
                    u => u.IdUnidad,
                    (i, u) => new InsumoUiRequest
                    {
                        IdInsumo = i.IdInsumo,
                        InsumoNombre = i.Nombre,
                        UnidadMedida = u.Abreviacion
                    }).ToListAsync();
        }

        public async Task<Insumo> InsertUiInsumo(Insumo insumo)
        {
            await dbset.AddAsync(insumo);
            await db.SaveChangesAsync();
            return insumo;
        }

        public async Task<Insumo> UpdateUiInsumo(Insumo insumo)
        {
            dbset.Update(insumo);
            await db.SaveChangesAsync();
            return insumo;
        }

        public async Task<bool> DeleteUiInsumo(int idInsumo)
        {
            var insumo = await db.Insumos.FindAsync(idInsumo);
            if (insumo == null)
            {
                throw new ArgumentNullException(nameof(insumo), "Insumo no encontrado");
            }
            db.Insumos.Remove(insumo);
            await db.SaveChangesAsync();
            return true;
        }
        public async Task<Insumo> BuscarporId(int id)
        {
            return await db.Insumos.FindAsync(id);
        }

        public async Task<Insumo> BuscarNombre(string nombre)
        {
            return await db.Insumos.FirstOrDefaultAsync(i => i.Nombre == nombre);
        }
        public async Task<GenericFilterResponse<InsumoUiRequest>> GetByFilterViewAsync(GenericFilterRequest request)
        {
            List<InsumoUiRequest> list = await UiInsumo();
            var query = list.Where(x => x.IdInsumo == x.IdInsumo);
            request.Filtros.ForEach(j =>
            {
                if (!string.IsNullOrEmpty(j.Value))
                {
                    switch (j.Name)
                    {
                        case "Insumo":
                            query = query.Where(x => x.IdInsumo == int.Parse(j.Value));
                            break;
                    }
                }
            });

            GenericFilterResponse<InsumoUiRequest> res = new();

            res.TotalRegistros = query.Count();
            res.Lista = query
                //.Include(x => x.Status)
                .Skip((request.NumeroPagina - 1) * request.Cantidad)
                .Take(request.Cantidad)
                .OrderBy(x => x.IdInsumo)
                .ToList();

            return res;
        }

        public async Task BuscarInsumoNombre(string insumo)
        {
            

        }
    }
}
