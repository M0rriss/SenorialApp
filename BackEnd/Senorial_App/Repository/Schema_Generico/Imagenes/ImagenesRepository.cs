using DBSenorialModels.Senorial;
using IRepository.Schema_Generico.Imagenes;
using Microsoft.EntityFrameworkCore;
using Repository.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Schema_Generico.Imagenes
{
    public class ImagenesRepository : CrudRepository<Imagene>, IImagenesRepository
    {
        public async Task<GenericFilterResponse<Imagene>> GetByFilterAsync(GenericFilterRequest request)
        {
            throw new NotImplementedException();
        }


        public async Task<Imagene> GetImageByIdAsync(int id)
        {
            return await db.Imagenes.FindAsync(id);
        }

        public async Task<int> SaveTemporaryImageAsync(Imagene imageEntity)
        {
            db.Imagenes.Add(imageEntity);
            await db.SaveChangesAsync();
            return imageEntity.Id;
        }
        public async Task DeleteImageAsync(int id)
        {
            var image = await db.Imagenes.FindAsync(id);
            if (image != null)
            {
                db.Imagenes.Remove(image);
                await db.SaveChangesAsync();
            }
        }
    }
   
}
