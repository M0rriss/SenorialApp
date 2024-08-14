using AutoMapper;
using Business.Schema_Almacen.Inventarios;
using IBusiness.Schema_Almacen.Inventarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RequestResponseModels.Request.Schema_Almacen.DetalleInventarios;
using RequestResponseModels.Request.Schema_Almacen.Entradas;
using RequestResponseModels.Request.Schema_Almacen.Inventario;
using RequestResponseModels.Request.Schema_Produccion.Salidas;
using RequestResponseModels.Response.Schema_Almacen.DetalleInventarios;
using RequestResponseModels.Response.Schema_Almacen.Entradas;
using RequestResponseModels.Response.Schema_Almacen.Inventario;
using RequestResponseModels.Response.Schema_Generico.GenericResponse;
using RequestResponseModels.Response.Schema_Produccion.Salidas;
using System.Net;

namespace App_Senorial.Controllers.Schema_Almacen.Inventario
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class InventarioController : ControllerBase
    {
        #region DECLARACION DE VARIABLE Y CONSTRUCTOR
        private readonly IInventarioBusiness _inventarioBusiness;
        private readonly IMapper _mapper;
        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        /// <param name="mapper"></param>
        public InventarioController(IMapper mapper)
        {
            _mapper = mapper;
            _inventarioBusiness = new InventarioBusiness(mapper);
        }
        #endregion
        #region CRUD
        /// <summary>
        /// Obtiene la lista de todos los inventarios.
        /// </summary>
        /// <returns>Una lista de respuestas de inventario.</returns>
        [HttpGet, Route("Listado")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<InventarioResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> GetAllInventarios()
        {
            var response = await _inventarioBusiness.GetAllInventarios();
            return Ok(response);
        }

        /// <summary>
        /// Obtiene un inventario por su ID.
        /// </summary>
        /// <param name="id">ID del inventario.</param>
        /// <returns>Una respuesta de inventario.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(InventarioResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> GetInventarioById(int id)
        {
            var result = await _inventarioBusiness.GetInventarioById(id);
            return Ok(result);
        }

        /// <summary>
        /// Crea un nuevo inventario.
        /// </summary>
        /// <param name="request">Datos del nuevo inventario.</param>
        /// <returns>La respuesta del inventario creado.</returns>
        [HttpPost, Route("Crear")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(InventarioResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> CreateInventario([FromBody] InventarioRequest request)
        {
            var result = await _inventarioBusiness.CreateInventario(request);
            return Ok(result);
        }

        /// <summary>
        /// Actualiza un inventario existente.
        /// </summary>
        /// <param name="request">Datos actualizados del inventario.</param>
        /// <returns>La respuesta del inventario actualizado.</returns>
        [HttpPut, Route("Actualizar")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(InventarioResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> UpdateInventario([FromBody] InventarioRequest request)
        {
            var result = await _inventarioBusiness.UpdateInventario(request);
            return Ok(result);
        }

        /// <summary>
        /// Elimina un inventario por su ID.
        /// </summary>
        /// <param name="id">ID del inventario a eliminar.</param>
        /// <returns>Un valor booleano indicando si la eliminación fue exitosa.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> DeleteInventario(int id)
        {
            var result = await _inventarioBusiness.DeleteInventario(id);
            return Ok(result);
        }

        /// <summary>
        /// Crea un nuevo detalle de inventario.
        /// </summary>
        /// <param name="request">Datos del nuevo detalle de inventario.</param>
        /// <returns>La respuesta del detalle de inventario creado.</returns>
        [HttpPost, Route("CrearDetalle")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(DetalleInventarioResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> CreateDetalle([FromBody] DetalleInventarioRequest request)
        {
            var result = await _inventarioBusiness.CreateDetalle(request);
            return Ok(result);
        }

        /// <summary>
        /// Actualiza un detalle de inventario existente.
        /// </summary>
        /// <param name="request">Datos actualizados del detalle de inventario.</param>
        /// <returns>La respuesta del detalle de inventario actualizado.</returns>
        [HttpPut, Route("ActualizarDetalle")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(DetalleInventarioResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> UpdateDetalle([FromBody] DetalleInventarioRequest request)
        {
            var result = await _inventarioBusiness.UpdateDetalle(request);
            return Ok(result);
        }

        /// <summary>
        /// Elimina un detalle de inventario por su ID.
        /// </summary>
        /// <param name="id">ID del detalle de inventario a eliminar.</param>
        /// <returns>Un valor booleano indicando si la eliminación fue exitosa.</returns>
        [HttpDelete, Route("EliminarDetalle/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> DeleteDetalle(int id)
        {
            var result = await _inventarioBusiness.DeleteDetalle(id);
            return Ok(result);
        }

        /// <summary>
        /// Obtiene un detalle de inventario por su ID.
        /// </summary>
        /// <param name="id">ID del detalle de inventario.</param>
        /// <returns>Una respuesta de detalle de inventario.</returns>
        [HttpGet, Route("Detalle/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(DetalleInventarioResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> GetDetalleById(int id)
        {
            var result = await _inventarioBusiness.GetDetalleById(id);
            return Ok(result);
        }

        /// <summary>
        /// Obtiene todos los detalles de inventario por el ID de inventario.
        /// </summary>
        /// <param name="inventarioId">ID del inventario.</param>
        /// <returns>Una lista de respuestas de detalle de inventario.</returns>
        [HttpGet, Route("{inventarioId}/Detalles")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<DetalleInventarioResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> GetAllDetalles(int inventarioId)
        {
            var result = await _inventarioBusiness.GetAllDetalles(inventarioId);
            return Ok(result);
        }

        /// <summary>
        /// Crea una nueva entrada en el inventario.
        /// </summary>
        /// <param name="request">Datos de la nueva entrada.</param>
        /// <returns>La respuesta de la entrada creada.</returns>
        [HttpPost, Route("CrearEntrada")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(EntradaResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> CreateEntrada([FromBody] EntradaRequest request)
        {
            var result = await _inventarioBusiness.CreateEntrada(request);
            return Ok(result);
        }

        /// <summary>
        /// Actualiza una entrada existente en el inventario.
        /// </summary>
        /// <param name="request">Datos actualizados de la entrada.</param>
        /// <returns>La respuesta de la entrada actualizada.</returns>
        [HttpPut, Route("ActualizarEntrada")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(EntradaResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> UpdateEntrada([FromBody] EntradaRequest request)
        {
            var result = await _inventarioBusiness.UpdateEntrada(request);
            return Ok(result);
        }

        /// <summary>
        /// Elimina una entrada por su ID.
        /// </summary>
        /// <param name="id">ID de la entrada a eliminar.</param>
        /// <returns>Un valor booleano indicando si la eliminación fue exitosa.</returns>
        [HttpDelete, Route("EliminarEntrada/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> DeleteEntrada(int id)
        {
            var result = await _inventarioBusiness.DeleteEntrada(id);
            return Ok(result);
        }

        /// <summary>
        /// Obtiene una entrada por su ID.
        /// </summary>
        /// <param name="id">ID de la entrada.</param>
        /// <returns>Una respuesta de entrada.</returns>
        [HttpGet, Route("Entrada/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(EntradaResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> GetEntradaById(int id)
        {
            var result = await _inventarioBusiness.GetEntradaById(id);
            return Ok(result);
        }

        /// <summary>
        /// Obtiene todas las entradas por el ID de inventario.
        /// </summary>
        /// <param name="inventarioId">ID del inventario.</param>
        /// <returns>Una lista de respuestas de entrada.</returns>
        [HttpGet, Route("{inventarioId}/Entradas")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<EntradaResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> GetAllEntradas(int inventarioId)
        {
            var result = await _inventarioBusiness.GetAllEntradas(inventarioId);
            return Ok(result);
        }

        /// <summary>
        /// Crea una nueva salida del inventario.
        /// </summary>
        /// <param name="request">Datos de la nueva salida.</param>
        /// <returns>La respuesta de la salida creada.</returns>
        [HttpPost, Route("CrearSalida")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(SalidaResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> CreateSalida([FromBody] SalidaRequest request)
        {
            var result = await _inventarioBusiness.CreateSalida(request);
            return Ok(result);
        }

        /// <summary>
        /// Actualiza una salida existente del inventario.
        /// </summary>
        /// <param name="request">Datos actualizados de la salida.</param>
        /// <returns>La respuesta de la salida actualizada.</returns>
        [HttpPut, Route("ActualizarSalida")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(SalidaResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> UpdateSalida([FromBody] SalidaRequest request)
        {
            var result = await _inventarioBusiness.UpdateSalida(request);
            return Ok(result);
        }

        /// <summary>
        /// Elimina una salida por su ID.
        /// </summary>
        /// <param name="id">ID de la salida a eliminar.</param>
        /// <returns>Un valor booleano indicando si la eliminación fue exitosa.</returns>
        [HttpDelete, Route("EliminarSalida/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> DeleteSalida(int id)
        {
            var result = await _inventarioBusiness.DeleteSalida(id);
            return Ok(result);
        }

        /// <summary>
        /// Obtiene una salida por su ID.
        /// </summary>
        /// <param name="id">ID de la salida.</param>
        /// <returns>Una respuesta de salida.</returns>
        [HttpGet, Route("Salida/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(SalidaResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> GetSalidaById(int id)
        {
            var result = await _inventarioBusiness.GetSalidaById(id);
            return Ok(result);
        }

        /// <summary>
        /// Obtiene todas las salidas por el ID de inventario.
        /// </summary>
        /// <param name="inventarioId">ID del inventario.</param>
        /// <returns>Una lista de respuestas de salida.</returns>
        [HttpGet, Route("{inventarioId}/Salidas")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<SalidaResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> GetAllSalidas(int inventarioId)
        {
            var result = await _inventarioBusiness.GetAllSalidas(inventarioId);
            return Ok(result);
        }
        #endregion
    }
}
