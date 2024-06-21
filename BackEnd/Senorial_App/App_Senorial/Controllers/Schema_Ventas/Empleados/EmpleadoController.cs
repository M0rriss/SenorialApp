using AutoMapper;
using Business.Schema_Ventas.Empleados;
using IBusiness.Schema_Ventas.Empleados;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
