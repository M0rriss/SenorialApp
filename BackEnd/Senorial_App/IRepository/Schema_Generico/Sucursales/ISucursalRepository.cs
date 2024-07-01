using DBSenorialModels.Senorial;
using IRepository.Schema_Generico.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Schema_Generico.Sucursales
{
    public interface ISucursalRepository : ICrudRepository<Sucursal>
    {
        Task<Sucursal> GetBySucursalName(string sucursalName);
    }
}
