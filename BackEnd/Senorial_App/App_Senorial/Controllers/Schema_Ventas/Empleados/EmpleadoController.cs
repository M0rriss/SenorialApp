using AutoMapper;
using Business.Schema_Ventas.Empleados;
using DBSenorialModels.Senorial;
using IBusiness.Schema_Ventas.Empleados;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestResponseModels.Request.Schema_Ventas.Empleados;
using RequestResponseModels.Response.Schema_Generico.GenericResponse;
using RequestResponseModels.Response.Schema_Ventas.Empleados;
using System.Net;

namespace App_Senorial.Controllers.Schema_Ventas.Empleados
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        #region DECLARACION DE VARIABLE Y CONSTRUCTOR
        private readonly IEmpleadoBusiness _empleadoBusiness;
        private readonly IMapper _mapper;
        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        /// <param name="mapper"></param>
        public EmpleadoController(IMapper mapper)
        {
            _mapper = mapper;
            _empleadoBusiness = new EmpleadoBusiness(mapper);
        }
        #endregion DECLARACION DE VARIABLE Y CONSTRUCTOR

        /// <summary>
        /// RETORNA TODOS LOS REGISTROS DE LA TABLA EMPLEADO
        /// </summary>
        /// <returns>List-CategoriaResponse</returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<EmpleadoResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> Get()
        {
            var result = _empleadoBusiness.UiGetEmpleado();
            return Ok(result);
        }
        /// <summary>
        /// Inserta un nuevo empleado.
        /// </summary>
        /// <param name="request">Datos del Empleado a insertar.</param>
        /// <returns>EmpleadoUiResponse insertado.</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(EmpleadosUiResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> Create([FromBody] EmpleadosUiRequest request)
        {
            var empleadosInsert = await _empleadoBusiness.InsertUiEmpleado(request);
            return Ok(empleadosInsert);
        }
        /// <summary>
        /// Actualiza un empleado existente.
        /// </summary>
        /// <param name="request">Datos actualizados del empleado.</param>
        /// <returns>EmpleadoUiResponse actualizado.</returns>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(EmpleadosUiResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> Update([FromBody] EmpleadoUpdateUiRequest request)
        {
            var empleadoActualizado = await _empleadoBusiness.UpdateUiEmpleado(request);
            return Ok(empleadoActualizado);
        }
        /// <summary>
        /// Elimina un empleado existente.
        /// </summary>
        /// <param name="idEmpleado">ID del Empleado a eliminar.</param>
        /// <returns>ActionResult indicando el resultado de la eliminación.</returns>
        [HttpDelete("{idEmpleado}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(string))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> Delete(int idEmpleado)
        {
            await _empleadoBusiness.DeleteUiEmpleado(idEmpleado);
            return Ok("Empleado eliminado correctamente.");
        }
    }
}
