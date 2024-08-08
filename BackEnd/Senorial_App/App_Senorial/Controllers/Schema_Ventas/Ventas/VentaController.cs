using AutoMapper;
using Business.Schema_Ventas.Ventas;
using IBusiness.Schema_Ventas.Ventas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestResponseModels.Request.Schema_Ventas.Ventas;
using RequestResponseModels.Response.Schema_Generico.GenericResponse;
using RequestResponseModels.Response.Schema_Ventas.Ventas;
using System.Net;

namespace App_Senorial.Controllers.Schema_Ventas.Ventas
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VentaController : ControllerBase
    {
        private readonly IVentaBusiness _ventaBusiness;
        private  readonly IMapper _mapper;
        public VentaController(IMapper mapper)
        {
            _mapper = mapper;
            _ventaBusiness = new VentaBusiness(mapper);
        }
        #region CRUD METHODS

        /// <summary>
        /// Obtiene todas las ventas.
        /// </summary>
        /// <returns>Una lista de respuestas de ventas.</returns>
        /// <response code="200">Devuelve la lista de ventas.</response>
        /// <response code="400">Solicitud incorrecta.</response>
        /// <response code="500">Error interno del servidor.</response>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<VentasResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> GetAllVentas()
        {
            var result = await _ventaBusiness.GetAllVentas();
            return Ok(result);
        }

        /// <summary>
        /// Obtiene una venta por su ID.
        /// </summary>
        /// <param name="id">El ID de la venta.</param>
        /// <returns>Una respuesta de venta.</returns>
        /// <response code="200">Devuelve la venta solicitada.</response>
        /// <response code="400">Solicitud incorrecta.</response>
        /// <response code="500">Error interno del servidor.</response>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(VentasResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> GetVentaById(int id)
        {
            var result = await _ventaBusiness.GetVentaById(id);
            return Ok(result);
        }

        /// <summary>
        /// Crea una nueva venta.
        /// </summary>
        /// <param name="ventaRequest">La solicitud de creación de venta.</param>
        /// <returns>La respuesta de la venta creada.</returns>
        /// <response code="200">Venta creada exitosamente.</response>
        /// <response code="400">Solicitud incorrecta.</response>
        /// <response code="500">Error interno del servidor.</response>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(VentasResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> CreateVenta([FromBody] VentasRequest ventaRequest)
        {
            var result = await _ventaBusiness.CreateVenta(ventaRequest);
            return Ok(result);
        }

        /// <summary>
        /// Actualiza una venta existente.
        /// </summary>
        /// <param name="ventaRequest">La solicitud de actualización de venta.</param>
        /// <returns>La respuesta de la venta actualizada.</returns>
        /// <response code="200">Venta actualizada exitosamente.</response>
        /// <response code="400">Solicitud incorrecta.</response>
        /// <response code="500">Error interno del servidor.</response>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(VentasResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> UpdateVenta([FromBody] VentasRequest ventaRequest)
        {
            var result = await _ventaBusiness.UpdateVenta(ventaRequest);
            return Ok(result);
        }

        /// <summary>
        /// Elimina una venta por su ID.
        /// </summary>
        /// <param name="id">El ID de la venta a eliminar.</param>
        /// <returns>True si la venta fue eliminada exitosamente.</returns>
        /// <response code="200">Venta eliminada exitosamente.</response>
        /// <response code="400">Solicitud incorrecta.</response>
        /// <response code="500">Error interno del servidor.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> DeleteVenta(int id)
        {
            var result = await _ventaBusiness.DeleteVenta(id);
            return Ok(result);
        }

        #endregion CRUD METHODS
    }
}
