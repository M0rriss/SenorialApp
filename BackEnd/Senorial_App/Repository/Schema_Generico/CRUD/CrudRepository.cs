using DBSenorialModels.Data;
using Microsoft.EntityFrameworkCore;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Schema_Generico.CRUD
{
    public class CrudRepository<TEntity> where TEntity : class
    {
        #region Dependecy Injection
        internal DBSenorialContext db;
        internal DbSet<TEntity> dbset;
        public CrudRepository()
        {
            db = new DBSenorialContext();
            dbset = db.Set<TEntity>();
        }
        #endregion
        #region CRUD
        public async Task<List<TEntity>> GetAll() => await dbset.ToListAsync();
        public async Task<TEntity> GetById(int id) => await dbset.FindAsync(id);
        public async Task<TEntity> Create(TEntity entity)
        {
            await dbset.AddAsync(entity);
            await db.SaveChangesAsync();
            return entity;
        }
        public async Task<List<TEntity>> CreateMultiple(List<TEntity> list)
        {
            await dbset.AddRangeAsync(list);
            await db.SaveChangesAsync();
            return list;
        }
        public async Task<TEntity> Update(TEntity entity)
        {
            dbset.Update(entity);
            await db.SaveChangesAsync();
            return entity;
        }
        public async Task<List<TEntity>> UpdateMultiple(List<TEntity> list)
        {
            dbset.UpdateRange(list);
            await db.SaveChangesAsync();
            return list;
        }
        public async Task<int> Delete(int id)
        {
            TEntity? entity = await dbset.FindAsync(id);
            dbset.Remove(entity);
            return await db.SaveChangesAsync();
        }
        public async Task<List<TEntity>> DeleteMultiple(List<TEntity> list)
        {
            dbset.RemoveRange(list);
            await db.SaveChangesAsync();
            return list;
        }
        public async Task<GenericFilterResponse<TEntity>> GetByFilterAsync(GenericFilterRequest request, Dictionary<string, Expression<Func<TEntity, bool>>> filters)
        {
            IQueryable<TEntity> query = dbset.AsQueryable();

            foreach (var filter in request.Filtros)
            {
                if (!string.IsNullOrEmpty(filter.Value) && filters.ContainsKey(filter.Name))
                {
                    query = query.Where(filters[filter.Name]);
                }
            }

            GenericFilterResponse<TEntity> res = new GenericFilterResponse<TEntity>
            {
                TotalRegistros = await query.CountAsync(),
                Lista = await query
                    .Skip((request.NumeroPagina - 1) * request.Cantidad)
                    .Take(request.Cantidad)
                    .OrderBy(x => EF.Property<object>(x, "Nombre"))
                    .ToListAsync()
            };

            return res;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}