using CommonModels.Common;
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
        Task<List<CategoriaUiRequest>> UiGetCategoria();
        Task<CategoriaUiResponse> InsertUiCategoria(CategoriaUiRequest request);
        Task<CategoriaUiResponse> UpdateUiCategoria(CategoriaUpdateUiRequest request);
        Task<bool> DeleteUiCategoria(int id);
        Task<List<CategoriaResponse>> ListarCategoriasPadresAsync();
        Task<List<CategoriaResponse>> ListarSubCategoriaAsync(int idCategoria);
        Task<List<CategoriaResponse>> ListarTodasSubCategoriaAsync();

        Task<CustomResponse> CrearCategoriaPadre(CategoriaRequest req);
        Task<CustomResponse> CrearSubCategoria(CategoriaRequest req);
        Task<CustomResponse> EditarCategoriPadre(CategoriaRequest req);
        Task<CustomResponse> EditarsubCategori(CategoriaRequest req);
    }
}
