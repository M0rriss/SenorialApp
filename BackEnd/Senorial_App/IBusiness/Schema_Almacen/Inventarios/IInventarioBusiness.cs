using IBusiness.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Almacen.DetalleInventarios;
using RequestResponseModels.Request.Schema_Almacen.Entradas;
using RequestResponseModels.Request.Schema_Almacen.Inventario;
using RequestResponseModels.Request.Schema_Produccion.Salidas;
using RequestResponseModels.Response.Schema_Almacen.DetalleInventarios;
using RequestResponseModels.Response.Schema_Almacen.Entradas;
using RequestResponseModels.Response.Schema_Almacen.Inventario;
using RequestResponseModels.Response.Schema_Produccion.Salidas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Schema_Almacen.Inventarios
{
    public interface IInventarioBusiness : ICrudBusiness<InventarioRequest, InventarioResponse>
    {
        Task<InventarioResponse> CreateInventario(InventarioRequest request);
        Task<InventarioResponse> UpdateInventario(InventarioRequest request);
        Task<bool> DeleteInventario(int id);
        Task<InventarioResponse> GetInventarioById(int id);
        Task<List<InventarioResponse>> GetAllInventarios();

        Task<DetalleInventarioResponse> CreateDetalle(DetalleInventarioRequest request);
        Task<DetalleInventarioResponse> UpdateDetalle(DetalleInventarioRequest request);
        Task<bool> DeleteDetalle(int id);
        Task<DetalleInventarioResponse> GetDetalleById(int id);
        Task<List<DetalleInventarioResponse>> GetAllDetalles(int inventarioId);

        Task<EntradaResponse> CreateEntrada(EntradaRequest request);
        Task<EntradaResponse> UpdateEntrada(EntradaRequest request);
        Task<bool> DeleteEntrada(int id);
        Task<EntradaResponse> GetEntradaById(int id);
        Task<List<EntradaResponse>> GetAllEntradas(int inventarioId);

        Task<SalidaResponse> CreateSalida(SalidaRequest request);
        Task<SalidaResponse> UpdateSalida(SalidaRequest request);
        Task<bool> DeleteSalida(int id);
        Task<SalidaResponse> GetSalidaById(int id);
        Task<List<SalidaResponse>> GetAllSalidas(int inventarioId);
    }
}
