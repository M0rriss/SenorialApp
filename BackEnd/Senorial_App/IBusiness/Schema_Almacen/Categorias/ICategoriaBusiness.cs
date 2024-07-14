using IBusiness.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Almacen.Categorias;
using RequestResponseModels.Response.Schema_Almacen.Categorias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RequestResponseModels.Response.Schema_Almacen.Categorias.CategoriaResponse;


namespace IBusiness.Schema_Almacen.Categorias
{
    public interface ICategoriaBusiness : ICrudBusiness<CategoriaRequest, CategoriaResponse>
    {
        Task<List<CategoriaUiResponse>> UiGetCategoria();
        Task<CategoriaUiResponse> InsertUiCategoria(CategoriaUiRequest request);
        Task<CategoriaUiResponse> UpdateUiCategoria(CategoriaUpdateUiRequest request);
        Task<bool> DeleteUiCategoria(int id);
    }
}
