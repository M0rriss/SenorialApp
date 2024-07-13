using DBSenorialModels.Senorial;
using IRepository.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Almacen.Insumo;
using RequestResponseModels.Response.Schema_Almacen.Insumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Schema_Almacen.Insumos
{
    public interface IInsumoRepository : ICrudRepository<Insumo>
    {
        Task<List<InsumoUiRequest>> UiInsumo();
        Task<Insumo> InsertUiInsumo(Insumo insumo);
        Task<Insumo> UpdateUiInsumo(Insumo insumo);
        Task<bool> DeleteUiInsumo(int id);
        Task<Insumo> BuscarporId(int id);
        Task<Insumo> BuscarNombre(string nombre);
    }
}
