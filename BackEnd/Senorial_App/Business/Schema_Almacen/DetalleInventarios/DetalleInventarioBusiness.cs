using IBusiness.Schema_Almacen.DetalleInventarios;
using IBusiness.Schema_Almacen.DetalleInventarios;
using RequestResponseModels.Request.Schema_Almacen.DetalleInventarios;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Almacen.DetalleCompra;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Schema_Almacen.DetalleInventarios
{
    public class DetalleInventarioBusiness : IDetalleInventarioBusiness
    {
        
        public Task<DetalleCompraResponse> Create(DetalleInventarioRequest entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<DetalleCompraResponse>> CreateMultiple(List<DetalleInventarioRequest> list)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<DetalleInventarioRequest>> DeleteMultiple(List<DetalleInventarioRequest> list)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<List<DetalleCompraResponse>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<GenericFilterResponse<DetalleCompraResponse>> GetByFilterAsync(GenericFilterRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<DetalleCompraResponse> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<DetalleCompraResponse> Update(DetalleInventarioRequest entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<DetalleCompraResponse>> UpdateMultiple(List<DetalleInventarioRequest> list)
        {
            throw new NotImplementedException();
        }
    }
}
