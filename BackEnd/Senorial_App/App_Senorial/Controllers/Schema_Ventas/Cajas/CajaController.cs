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
using RequestResponseModels.Request.Schema_Ventas.Cajas;

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


        #region CRUD

        /// <summary>
        /// Obtiene todas las cajas.
        /// </summary>
        /// <returns>Una lista de cajas.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _cajaBusiness.GetAll();
            return Ok(response);
        }

        /// <summary>
        /// Obtiene una caja por su ID.
        /// </summary>
        /// <param name="id">El ID de la caja.</param>
        /// <returns>La caja solicitada.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _cajaBusiness.GetById(id);
            return Ok(response);
        }

        /// <summary>
        /// Crea una nueva caja.
        /// </summary>
        /// <param name="request">Datos de la caja a crear.</param>
        /// <returns>La caja creada.</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CajaRequest request)
        {
            var response = await _cajaBusiness.Create(request);
            return Ok(response);
        }

        /// <summary>
        /// Actualiza una caja existente.
        /// </summary>
        /// <param name="request">Datos de la caja a actualizar.</param>
        /// <returns>La caja actualizada.</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CajaRequest request)
        {
            var response = await _cajaBusiness.Update(request);
            return Ok(response);
        }

        /// <summary>
        /// Elimina una caja por su ID.
        /// </summary>
        /// <param name="id">El ID de la caja a eliminar.</param>
        /// <returns>Respuesta vacía si se elimina correctamente.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _cajaBusiness.Delete(id);
            return NoContent();
        }

        #endregion CRUD

        /// <summary>
        /// Realiza la apertura de una caja.
        /// </summary>
        /// <param name="request">Datos para la apertura de la caja.</param>
        /// <returns>La caja abierta.</returns>
        [HttpPost("apertura")]
        public async Task<IActionResult> AperturaCaja([FromBody] AperturaCajaRequest request)
        {
            var response = await _cajaBusiness.AperturarCaja(request);
            return Ok(response);
        }

        /// <summary>
        /// Obtiene el historial de aperturas de caja.
        /// </summary>
        /// <param name="request">Datos para filtrar el historial de aperturas.</param>
        /// <returns>El historial de aperturas de caja.</returns>
        [HttpPost("historial")]
        public async Task<IActionResult> HistorialApertura([FromBody] HistorialAperturaRequest request)
        {
            var response = await _cajaBusiness.ObtenerHistorialApertura(request);
            return Ok(response);
        }

        /// <summary>
        /// Realiza el cierre de una caja.
        /// </summary>
        /// <param name="request">Datos para el cierre de la caja.</param>
        /// <returns>Los detalles del cierre de la caja.</returns>
        [HttpPost("cierre")]
        public async Task<IActionResult> CierreCaja([FromBody] CierreCajaRequest request)
        {
            var response = await _aperturaCajaBusiness.CerrarCajaAsync(request);
            return Ok(response);
        }
    }
}
