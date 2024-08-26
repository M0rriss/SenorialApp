using AutoMapper;
using Business.Schema_Almacen.Proveedores;
using IBusiness.Schema_Almacen.Proveedores;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestResponseModels.Request.Schema_Almacen.Proveedor;
using RequestResponseModels.Response.Schema_Almacen.Proveedor;
using RequestResponseModels.Response.Schema_Generico.GenericResponse;
using System.Net;

namespace App_Senorial.Controllers.Schema_Almacen.Proveedor
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ProveedorController : ControllerBase
    {
        #region DECLARACION DE VARIABLE Y CONSTRUCTOR
        private readonly IProveedorBusiness _proveedorBusiness;
        private readonly IMapper _mapper;
        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        /// <param name="mapper"></param>
        public ProveedorController(IMapper mapper)
        {
            _mapper = mapper;
            _proveedorBusiness = new ProveedorBusiness(mapper);
        }
        #endregion DECLARACION DE VARIABLE Y CONSTRUCTOR

        /// <summary>
        /// RETORNA TODOS LOS REGISTROS DE LA TABLA Proveedor
        /// </summary>
        /// <returns>List-CategoriaResponse</returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<ProveedorResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> Get()
        {
            var result = await _proveedorBusiness.UiGetProveedor();
            return Ok(result);
        }
        /// <summary>
        /// Inserta un nuevo cliente.
        /// </summary>
        /// <param name="proveedor">Datos del Proveedor a insertar.</param>
        /// <returns>ClienteUiRequest insertado.</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(ProveedorResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> Create([FromBody] ProveedorUiRequest request)
        {
            var proveedorInsertado = await _proveedorBusiness.InsertUiProveedor(request);
            return Ok(proveedorInsertado);
        }

        /// <summary>
        /// Actualiza un cliente existente.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="id">ID del Proveedor a actualizar.</param>
        /// <param name="proveedor">Datos actualizados del cliente.</param>
        /// <returns>ClienteUiRequest actualizado.</returns>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ProveedorResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> Update([FromBody] ProveedorUpdateUiRequest request)
        {
            var proveedorActualizado = await _proveedorBusiness.UpdateUiProveedor(request);
            return Ok(proveedorActualizado);
        }
        /// <summary>
        /// Elimina un empleado existente.
        /// </summary>
        /// <param name="idEmpleado">ID del Empleado a eliminar.</param>
        /// <returns>ActionResult indicando el resultado de la eliminación.</returns>
        [HttpDelete("{idProveedor}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(string))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> Delete(int idProveedor)
        {
            await _proveedorBusiness.DeleteUiProveedor(idProveedor);
            return Ok("Empleado eliminado correctamente.");
        }
    }
}
