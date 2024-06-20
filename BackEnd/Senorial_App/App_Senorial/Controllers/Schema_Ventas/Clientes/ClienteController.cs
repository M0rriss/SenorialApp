using AutoMapper;
using Business.Schema_Almacen.Categorias;
using Business.Schema_Ventas.Clientes;
using IBusiness.Schema_Almacen.Categorias;
using IBusiness.Schema_Ventas.Cliente;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestResponseModels.Response.Schema_Almacen.Categorias;
using RequestResponseModels.Response.Schema_Generico.GenericResponse;
using System.Net;

namespace App_Senorial.Controllers.Schema_Ventas.Clientes
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        #region DECLARACION DE VARIABLE Y CONSTRUCTOR
        private readonly IClienteBusiness _clienteBusiness;
        private readonly IMapper _mapper;
        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        /// <param name="mapper"></param>
        public ClienteController(IMapper mapper)
        {
            _mapper = mapper;
            _clienteBusiness = new ClienteBusiness(mapper);
        }
        #endregion DECLARACION DE VARIABLE Y CONSTRUCTOR
        
        /// <summary>
        /// RETORNA TODOS LOS REGISTROS DE LA TABLA CLIENTES
        /// </summary>
        /// <returns>List-CategoriaResponse</returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<CategoriaResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> Get()
        {
            var result =  _clienteBusiness.GetFull();
            return Ok(result);
        }
    }
}