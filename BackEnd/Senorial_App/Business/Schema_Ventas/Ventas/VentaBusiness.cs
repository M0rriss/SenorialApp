using AutoMapper;
using DBSenorialModels.Senorial;
using IBusiness.Schema_Ventas.Ventas;
using IRepository.Schema_Ventas.Ventas;
using Repository.Schema_Ventas.Ventas;
using RequestResponseModels.Request.Schema_Ventas.Ventas;
using RequestResponseModels.Response.Schema_Ventas.Ventas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Schema_Ventas.Ventas
{
    public class VentaBusiness : IVentaBusiness
    {
        private readonly IVentaRepository _ventaRepository;
        private readonly IMapper _mapper;
        public VentaBusiness(IMapper mapper)
        {
            _mapper = mapper;
            _ventaRepository = new VentaRepository();
        }
        public async Task<VentasResponse> GetVentaById(int id)
        {
            var venta = await _ventaRepository.GetVentaById(id);
            return _mapper.Map<VentasResponse>(venta);
        }

        public async Task<List<VentasResponse>> GetAllVentas()
        {
            var ventas = await _ventaRepository.GetAllVentas();
            return _mapper.Map<List<VentasResponse>>(ventas);
        }

        public async Task<VentasResponse> CreateVenta(VentasRequest ventaRequest)
        {
            var venta = _mapper.Map<Venta>(ventaRequest);
            venta = await _ventaRepository.CreateVenta(venta);
            return _mapper.Map<VentasResponse>(venta);
        }

        public async Task<VentasResponse> UpdateVenta(VentasRequest ventaRequest)
        {
            var venta = _mapper.Map<Venta>(ventaRequest);
            venta = await _ventaRepository.UpdateVenta(venta);
            return _mapper.Map<VentasResponse>(venta);
        }

        public async Task<bool> DeleteVenta(int id)
        {
            return await _ventaRepository.DeleteVenta(id);
        }
    }
}
