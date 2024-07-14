using AutoMapper;
using Business.Schema_Almacen.Categorias;
using IBusiness.Schema_Almacen.Categorias;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestResponseModels.Request.Schema_Almacen.Categorias;
using RequestResponseModels.Response.Schema_Almacen.Categorias;
using RequestResponseModels.Response.Schema_Generico.GenericResponse;
using System.Net;
using static RequestResponseModels.Response.Schema_Almacen.Categorias.CategoriaResponse;

namespace App_Senorial.Controllers.Schema_Almacen.Categorias
{
    /// <summary>
    /// API CATEGORIA
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    
    public class CategoriaController : ControllerBase
    {
        #region DECLARACION DE VARIABLE Y CONSTRUCTOR
        private readonly ICategoriaBusiness _categoriaBusiness;
        private readonly IMapper _mapper;
        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        /// <param name="mapper"></param>
        public CategoriaController(IMapper mapper)
        {
            _mapper = mapper;
            _categoriaBusiness = new CategoriaBusiness(mapper);
        }
        #endregion DECLARACION DE VARIABLE Y CONSTRUCTOR
        #region CRUD METHODS
        /// <summary>
        /// RETORNA TODOS LOS REGISTROS DE LA TABLA Categoria
        /// </summary>
        /// <returns>List-CategoriaResponse</returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<CategoriaResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> Get()
        {
            var result = await _categoriaBusiness.GetAll();
            return Ok(result);
        }
        /// <summary>
        /// RETORNA EL REGISTRO DE LA TABLA FILTRADO POR EL PRIMARY KEY
        /// </summary>
        /// <param name="id">PRIMARY KEY</param>
        /// <returns>CategoriaResponse</returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(CategoriaResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _categoriaBusiness.GetById(id);
            return Ok(result);
        }
        /// <summary>
        /// INSERTA UN REGISTRO EN LA TABLA Categoria
        /// </summary>
        /// <param name="request">CategoriaRequest</param>
        /// <returns>CategoriaResponse</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(CategoriaResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> Create([FromBody] CategoriaRequest request)
        {
            var result = await _categoriaBusiness.Create(request);
            return Ok(result);
        }
        /// <summary>
        /// ACTUALIZA UN REGISTRO EN LA TABLA Categoria
        /// </summary>
        /// <param name="request">CategoriaRequest</param>
        /// <returns>CategoriaResponse</returns>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(CategoriaResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> Update([FromBody] CategoriaRequest request)
        {
            var result = await _categoriaBusiness.Update(request);
            return Ok(result);
        }
        
        #endregion CRUD METHODS
        #region UI Methods
        [HttpGet, Route("Listado")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<CategoriaUiResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<IActionResult> UiGetCategoria()
        {
            var response = await _categoriaBusiness.UiGetCategoria();
            return Ok(response);
        }

        [HttpPost, Route("Crear")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(CategoriaUiResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<IActionResult> InsertUiCategoria([FromBody] CategoriaUiRequest request)
        {
            var response = await _categoriaBusiness.InsertUiCategoria(request);
            return Ok(response);
        }

        [HttpPut, Route("Actualizar")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(CategoriaUiResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<IActionResult> UpdateUiCategoria([FromBody] CategoriaUpdateUiRequest request)
        {
            var response = await _categoriaBusiness.UpdateUiCategoria(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<IActionResult> DeleteUiCategoria(int id)
        {
            var response = await _categoriaBusiness.DeleteUiCategoria(id);
            return Ok(response);
        }
        #endregion
    }
}
