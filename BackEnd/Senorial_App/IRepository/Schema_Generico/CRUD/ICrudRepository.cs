
using DBSenorialModels.Senorial;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Generico.Filtro;

namespace IRepository.Schema_Generico.CRUD
{
    /// <summary>
    /// Interface para operaciones CRUD genéricas.
    /// </summary>
    /// <typeparam name="T">Tipo de entidad</typeparam>
    public interface ICrudRepository<T> : IDisposable
    {
        /// <summary>
        /// Obtener todos los registros de la tabla <typeparamref name="T"/> de forma asincrónica.
        /// </summary>
        /// <returns>Tarea que representa una lista de <typeparamref name="T"/></returns>
        Task<List<T>> GetAll();

        /// <summary>
        /// Obtener un registro por ID en la tabla <typeparamref name="T"/> de forma asincrónica.
        /// </summary>
        /// <param name="id">ID del registro</param>
        /// <returns>Tarea que representa el registro de tipo <typeparamref name="T"/></returns>
        Task<T> GetById(int id);

        /// <summary>
        /// Crear un nuevo registro en la tabla <typeparamref name="T"/> de forma asincrónica.
        /// </summary>
        /// <param name="entity">Entidad de tipo <typeparamref name="T"/></param>
        /// <returns>Tarea que representa el registro creado de tipo <typeparamref name="T"/></returns>
        Task<T> Create(T entity);

        /// <summary>
        /// Crear varios registros en la tabla <typeparamref name="T"/> de forma asincrónica.
        /// </summary>
        /// <param name="list">Lista de entidades de tipo <typeparamref name="T"/></param>
        /// <returns>Tarea que representa una lista de registros creados de tipo <typeparamref name="T"/></returns>
        Task<List<T>> CreateMultiple(List<T> list);

        /// <summary>
        /// Actualizar un registro en la tabla <typeparamref name="T"/> de forma asincrónica.
        /// </summary>
        /// <param name="entity">Entidad de tipo <typeparamref name="T"/></param>
        /// <returns>Tarea que representa el registro actualizado de tipo <typeparamref name="T"/></returns>
        Task<T> Update(T entity);

        /// <summary>
        /// Actualizar varios registros en la tabla <typeparamref name="T"/> de forma asincrónica.
        /// </summary>
        /// <param name="list">Lista de entidades de tipo <typeparamref name="T"/></param>
        /// <returns>Tarea que representa una lista de registros actualizados de tipo <typeparamref name="T"/></returns>
        Task<List<T>> UpdateMultiple(List<T> list);

        /// <summary>
        /// Eliminar un registro por ID en la tabla <typeparamref name="T"/> de forma asincrónica.
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
        Task<GenericFilterResponse<T>> GetByFilterAsync(GenericFilterRequest request);
    }
}
