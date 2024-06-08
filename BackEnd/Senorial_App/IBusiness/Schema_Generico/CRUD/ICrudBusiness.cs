using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Schema_Generico.CRUD
{
    /// <summary>
    /// Interface para operaciones CRUD genéricas.
    /// </summary>
    /// <typeparam name="T">Tipo de entidad para operaciones CRUD</typeparam>
    /// <typeparam name="Y">Tipo de entidad de respuesta</typeparam>
    public interface ICrudBusiness<T, Y> : IDisposable
    {
        /// <summary>
        /// Obtener todos los registros de la tabla <typeparamref name="Y"/> de forma asincrónica.
        /// </summary>
        /// <returns>Tarea que representa una lista de <typeparamref name="Y"/></returns>
        Task<List<Y>> GetAll();

        /// <summary>
        /// Obtener un registro por ID en la tabla <typeparamref name="Y"/> de forma asincrónica.
        /// </summary>
        /// <param name="id">ID del registro</param>
        /// <returns>Tarea que representa el registro de tipo <typeparamref name="Y"/></returns>
        Task<Y> GetById(int id);

        /// <summary>
        /// Crear un nuevo registro en la tabla <typeparamref name="T"/> de forma asincrónica.
        /// </summary>
        /// <param name="entity">Entidad de tipo <typeparamref name="T"/></param>
        /// <returns>Tarea que representa el registro creado de tipo <typeparamref name="Y"/></returns>
        Task<Y> Create(T entity);

        /// <summary>
        /// Crear varios registros en la tabla <typeparamref name="T"/> de forma asincrónica.
        /// </summary>
        /// <param name="list">Lista de entidades de tipo <typeparamref name="T"/></param>
        /// <returns>Tarea que representa una lista de registros creados de tipo <typeparamref name="Y"/></returns>
        Task<List<Y>> CreateMultiple(List<T> list);

        /// <summary>
        /// Actualizar un registro en la tabla <typeparamref name="T"/> de forma asincrónica.
        /// </summary>
        /// <param name="entity">Entidad de tipo <typeparamref name="T"/></param>
        /// <returns>Tarea que representa el registro actualizado de tipo <typeparamref name="Y"/></returns>
        Task<Y> Update(T entity);

        /// <summary>
        /// Actualizar varios registros en la tabla <typeparamref name="T"/> de forma asincrónica.
        /// </summary>
        /// <param name="list">Lista de entidades de tipo <typeparamref name="T"/></param>
        /// <returns>Tarea que representa una lista de registros actualizados de tipo <typeparamref name="Y"/></returns>
        Task<List<Y>> UpdateMultiple(List<T> list);

        /// <summary>
        /// Eliminar un registro por ID en la tabla <typeparamref name="Y"/> de forma asincrónica.
        /// </summary>
        /// <param name="id">ID del registro</param>
        /// <returns>Tarea que representa el ID del registro eliminado</returns>
        Task<int> Delete(int id);

        /// <summary>
        /// Eliminar varios registros en la tabla <typeparamref name="T"/> de forma asincrónica.
        /// </summary>
        /// <param name="list">Lista de entidades de tipo <typeparamref name="T"/></param>
        /// <returns>Tarea que representa una lista de IDs de los registros eliminados</returns>
        Task<List<T>> DeleteMultiple(List<T> list);

        /// <summary>
        /// Obtener registros por filtro en la tabla <typeparamref name="Y"/> de forma asincrónica.
        /// </summary>
        /// <param name="request">Solicitud de filtro</param>
        /// <returns>Tarea que representa la respuesta del filtro</returns>
        Task<GenericFilterResponse<Y>> GetByFilterAsync(GenericFilterRequest request);
    }
}