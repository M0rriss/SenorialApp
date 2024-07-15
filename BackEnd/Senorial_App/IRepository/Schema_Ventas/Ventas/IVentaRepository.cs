using DBSenorialModels.Senorial;
using IRepository.Schema_Generico.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Schema_Ventas.Ventas
{
    public interface IVentaRepository : ICrudRepository<Venta>
    {
        Task<Venta> GetVentaById(int id);
        Task<List<Venta>> GetAllVentas();
        Task<Venta> CreateVenta(Venta venta);
        Task<Venta> UpdateVenta(Venta venta);
        Task<bool> DeleteVenta(int id);
    }
}
