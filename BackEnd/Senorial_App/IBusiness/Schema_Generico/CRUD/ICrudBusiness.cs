using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Schema_Generico.CRUD
{
    public interface ICrudBusiness<T,Y> : IDisposable
    {
        Task<List<Y>> GetAll();
        Task<Y> GetById(int id);
        Task<Y> Create(T entity);
        Task<List<Y>> CreateMultiple(List<T> list);
        Task<Y> Update(T entity);
        Task<List<Y>> UpdeteMultiple(List<T> list);
        Task<int> Delete(int id);
        Task<List<T>> DeleteMultiple(List<T> list);
    }
}
