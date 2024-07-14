using DBSenorialModels.Senorial;
using IRepository.Schema_Generico.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Schema_Almacen.Inventarios
{
    public interface IInventarioRepository : ICrudRepository<Inventario>
    {
        Task<DetalleInventario> CreateDetalle(DetalleInventario entity);
        Task<DetalleInventario> UpdateDetalle(DetalleInventario entity);
        Task<bool> DeleteDetalle(int id);
        Task<DetalleInventario> GetDetalleById(int id);
        Task<List<DetalleInventario>> GetAllDetalles(int inventarioId);

        Task<Entrada> CreateEntrada(Entrada entity);
        Task<Entrada> UpdateEntrada(Entrada entity);
        Task<bool> DeleteEntrada(int id);
        Task<Entrada> GetEntradaById(int id);
        Task<List<Entrada>> GetAllEntradas(int inventarioId);

        Task<Salida> CreateSalida(Salida entity);
        Task<Salida> UpdateSalida(Salida entity);
        Task<bool> DeleteSalida(int id);
        Task<Salida> GetSalidaById(int id);
        Task<List<Salida>> GetAllSalidas(int inventarioId);
    }
}
