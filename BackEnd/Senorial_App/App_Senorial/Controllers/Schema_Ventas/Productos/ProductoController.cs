using AutoMapper;
using Business.Schema_Almacen.Categorias;
using Business.Schema_Ventas.Productos;
using IBusiness.Schema_Almacen.Categorias;
using IBusiness.Schema_Ventas.Productos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestResponseModels.Request.Schema_Almacen.Categorias;
using RequestResponseModels.Request.Schema_Ventas.Productos;
using RequestResponseModels.Response.Schema_Almacen.Categorias;
using RequestResponseModels.Response.Schema_Generico.GenericResponse;
using RequestResponseModels.Response.Schema_Ventas.Mesas;
using RequestResponseModels.Response.Schema_Ventas.Productos;
using System.Net;

namespace App_Senorial.Controllers.Schema_Ventas.Productos
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        #region DECLARACION DE VARIABLE Y CONSTRUCTOR
        private readonly IProductoBusiness _productoBusiness;
        private readonly IMapper _mapper;
        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        /// <param name="mapper"></param>
        public ProductoController(IMapper mapper)
        {
            _mapper = mapper;
            _productoBusiness = new ProductoBusiness(mapper);
        }
        #endregion DECLARACION DE VARIABLE Y CONSTRUCTOR
        #region CRUD METHODS
        /// <summary>
        /// RETORNA TODOS LOS REGISTROS DE LA TABLA Producto
        /// </summary>
        /// <returns>List-ProductoRequest</returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<ProductoRequest>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> Get()
        {
            var result = await _productoBusiness.GetAll();
            return Ok(result);
        }
        /// <summary>
        /// RETORNA EL REGISTRO DE LA TABLA FILTRADO POR EL PRIMARY KEY
        /// </summary>
        /// <param name="id">PRIMARY KEY</param>
        /// <returns>ProductoRequest</returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ProductoRequest))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _productoBusiness.GetById(id);
            return Ok(result);
        }
        /// <summary>
        /// INSERTA UN REGISTRO EN LA TABLA Producto
        /// </summary>
        /// <param name="request">ProductoRequest</param>
        /// <returns>ProductoRequest</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ProductoRequest))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> Create([FromBody] ProductoRequest request)
        {
            var result = await _productoBusiness.Create(request);
            return Ok(result);
        }
        /// <summary>
        /// ACTUALIZA UN REGISTRO EN LA TABLA Producto
        /// </summary>
        /// <param name="request">ProductoRequest</param>
        /// <returns>ProductoRequest</returns>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ProductoRequest))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> Update([FromBody] ProductoRequest request)
        {
            var result = await _productoBusiness.Update(request);
            return Ok(result);
        }
        #endregion CRUD METHODS
        #region UI CRUD
        [HttpGet, Route("Listado")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<ProductoUiResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> UiGetProducto()
        {
            var response = await _productoBusiness.UiGetProducto();
            return Ok(response);
        }
        [HttpPost, Route("Crear/Producto")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ProductoResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> CreateUi([FromBody] ProductoUiRequest request)
        {
            var result = await _productoBusiness.InsertUiProducto(request);
            return Ok(result);
        }

        [HttpPut, Route("Actualizar/Producto")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ProductoResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> UpdateUi([FromBody] ProductoUpdateUiRequest request)
        {
            var result = await _productoBusiness.UpdateUiProducto(request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ProductoResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> DeleteUi(int id)
        {
            var result = await _productoBusiness.DeleteUiProducto(id);
            return Ok(result);
        }
        #endregion UI CRUD


    }
}
