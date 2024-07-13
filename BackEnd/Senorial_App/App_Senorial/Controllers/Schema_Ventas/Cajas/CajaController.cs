using Business.Schema_Ventas.AperturaCajas;
using Business.Schema_Ventas.Cajas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestResponseModels.Request.Schema_Ventas.AperturaCaja.Cierre;
using RequestResponseModels.Request.Schema_Ventas.AperturaCaja.HistorialCaja;
using RequestResponseModels.Request.Schema_Ventas.AperturaCaja;
using AutoMapper;
using Business.Schema_Ventas.Clientes;
using IBusiness.Schema_Ventas.Cliente;
using IBusiness.Schema_Ventas.Cajas;
using IBusiness.Schema_Ventas.AperturaCajas;

namespace App_Senorial.Controllers.Schema_Ventas.Cajas
{
    [Route("api/[controller]")]
    [ApiController]
    public class CajaController : ControllerBase
    {
        #region DECLARACION DE VARIABLE Y CONSTRUCTOR
        private readonly ICajaBusiness _cajaBusiness;
        private readonly IAperturaCajaBusiness _aperturaCajaBusiness;
        private readonly IMapper _mapper;
        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        /// <param name="mapper"></param>
        public CajaController(IMapper mapper)
        {
            _mapper = mapper;
            _cajaBusiness = new CajaBusiness(mapper);
            _aperturaCajaBusiness = new AperturaCajaBusiness(mapper);
        }
        #endregion DECLARACION DE VARIABLE Y CONSTRUCTOR



        [HttpPost("apertura")]
        public async Task<IActionResult> AperturaCaja([FromBody] AperturaCajaRequest request)
        {
            var response = await _cajaBusiness.AperturarCaja(request);
            return Ok(response);
        }

        [HttpPost("historial")]
        public async Task<IActionResult> HistorialApertura([FromBody] HistorialAperturaRequest request)
        {
            var response = await _cajaBusiness.ObtenerHistorialApertura(request);
            return Ok(response);
        }

        [HttpPost("cierre")]
        public async Task<IActionResult> CierreCaja([FromBody] CierreCajaRequest request)
        {
            var response = await _aperturaCajaBusiness.CerrarCajaAsync(request);
            return Ok(response);
        }
    }
}
