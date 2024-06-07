using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Schema_Generico.CRUD
{
    public interface ICrudRepository<T> : IDisposable
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Create(T entity);
        Task<List<T>> CreateMultiple(List<T> list);
        Task<T> Update(T entity);
        Task<List<T>> UpdateMultiple(List<T> list);
        Task<int> Delete(int id);
        Task<List<T>> DeleteMultiple(List<T> list);
    }
}
