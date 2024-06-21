using AutoMapper;
using Business.Schema_Almacen.Proveedores;
using Business.Schema_Ventas.Clientes;
using IBusiness.Schema_Almacen.Proveedores;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestResponseModels.Response.Schema_Almacen.Proveedor;
using RequestResponseModels.Response.Schema_Generico.GenericResponse;
using System.Net;

namespace App_Senorial.Controllers.Schema_Almacen.Proveedor
{
    [Route("api/[controller]")]
    [ApiController]
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
            var result = _proveedorBusiness.UiGetProveedor();
            return Ok(result);
        }
    }
}
