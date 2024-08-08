using IBusiness.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Almacen.Insumo;
using RequestResponseModels.Response.Schema_Almacen.Insumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Schema_Almacen.Insumos
{
    public interface IInsumoBusiness : ICrudBusiness<InsumoRequest, InsumoResponse>
    {
        Task<List<InsumoUiRequest>> UiGetInsumo(); // Añadimos esta línea
        Task<InsumoUiResponse> InsertUiInsumo(InsumoUiRequest request);
        Task<InsumoUiResponse> UpdateUiInsumo(InsumoUpdateUiRequest request);
        Task<bool> DeleteUiInsumo(int idInsumo);
    }
}
