using DBSenorialModels.Senorial;
using IRepository.Schema_Almacen.Inventarios;
using Microsoft.EntityFrameworkCore;
using Repository.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Schema_Almacen.Inventarios
{
    public class InventarioRepository : CrudRepository<Inventario>, IInventarioRepository
    {
        public Task<GenericFilterResponse<Inventario>> GetByFilterAsync(GenericFilterRequest request)
        {
            throw new NotImplementedException();
        }
        public async Task<DetalleInventario> CreateDetalle(DetalleInventario entity)
        {
            db.DetalleInventarios.Add(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public async Task<DetalleInventario> UpdateDetalle(DetalleInventario entity)
        {
            db.DetalleInventarios.Update(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteDetalle(int id)
        {
            var entity = await db.DetalleInventarios.FindAsync(id);
            if (entity == null)
            {
                return false;
            }

            db.DetalleInventarios.Remove(entity);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<DetalleInventario> GetDetalleById(int id)
        {
            return await db.DetalleInventarios.FindAsync(id);
        }

        public async Task<List<DetalleInventario>> GetAllDetalles(int inventarioId)
        {
            return await db.DetalleInventarios.Where(d => d.IdInventario == inventarioId).ToListAsync();
        }

        public async Task<Entrada> CreateEntrada(Entrada entity)
        {
            db.Entradas.Add(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public async Task<Entrada> UpdateEntrada(Entrada entity)
        {
            db.Entradas.Update(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteEntrada(int id)
        {
            var entity = await db.Entradas.FindAsync(id);
            if (entity == null)
            {
                return false;
            }

            db.Entradas.Remove(entity);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<Entrada> GetEntradaById(int id)
        {
            return await db.Entradas.FindAsync(id);
        }

        public async Task<List<Entrada>> GetAllEntradas(int inventarioId)
        {
            return await db.Entradas.Where(e => e.IdInventario == inventarioId).ToListAsync();
        }

        public async Task<Salida> CreateSalida(Salida entity)
        {
            db.Salidas.Add(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public async Task<Salida> UpdateSalida(Salida entity)
        {
            db.Salidas.Update(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteSalida(int id)
        {
            var entity = await db.Salidas.FindAsync(id);
            if (entity == null)
            {
                return false;
            }

            db.Salidas.Remove(entity);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<Salida> GetSalidaById(int id)
        {
            return await db.Salidas.FindAsync(id);
        }

        public async Task<List<Salida>> GetAllSalidas(int inventarioId)
        {
            return await db.Salidas.Where(s => s.IdInventario == inventarioId).ToListAsync();
        }
    }
}
