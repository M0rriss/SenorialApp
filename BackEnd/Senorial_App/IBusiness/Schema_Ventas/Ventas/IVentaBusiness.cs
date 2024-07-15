using IBusiness.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Ventas.Ventas;
using RequestResponseModels.Response.Schema_Ventas.Ventas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Schema_Ventas.Ventas
{
    public interface IVentaBusiness 
    {
        Task<VentasResponse> GetVentaById(int id);
        Task<List<VentasResponse>> GetAllVentas();
        Task<VentasResponse> CreateVenta(VentasRequest ventaRequest);
        Task<VentasResponse> UpdateVenta(VentasRequest ventaRequest);
        Task<bool> DeleteVenta(int id);
    }
}
