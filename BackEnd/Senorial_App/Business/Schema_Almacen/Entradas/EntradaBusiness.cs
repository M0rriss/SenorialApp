using CommonModels.Common;
using DBSenorialModels.Senorial;
using IBusiness.Schema_Almacen.Entradas;
using IRepository.Schema_Almacen.Entradas;
using Repository.Schema_Almacen.Entradas;
using RequestResponseModels.Request.Schema_Almacen.Entradas;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Almacen.Entradas;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Business.Schema_Almacen.Entradas
{
    public class EntradaBusiness : IEntradaBusiness
    {
        private readonly IEntradaRepository _entradaRepository;
        public EntradaBusiness()
        {
            _entradaRepository = new EntradaRepository();
        }
        public Task<EntradaResponse> Create(EntradaRequest entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<EntradaResponse>> CreateMultiple(List<EntradaRequest> list)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<EntradaRequest>> DeleteMultiple(List<EntradaRequest> list)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<List<EntradaResponse>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<GenericFilterResponse<EntradaResponse>> GetByFilterAsync(GenericFilterRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<EntradaResponse> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<EntradaResponse> Update(EntradaRequest entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<EntradaResponse>> UpdateMultiple(List<EntradaRequest> list)
        {
            throw new NotImplementedException();
        }

        #region Funcionalidad

        public async Task<CustomResponse> RegistrarIngreso(EntradaRequest req)
        {
            Entrada entrada = new()
            {
                IdInsumo = req.IdInsumo,
                IdInventario = req.IdInsumo,
                Cantidad = req.Cantidad,
                FechaIngreso = DateTime.Now,
                PrecioCompra = req.PrecioCompra,
            };
            await _entradaRepository.RegistrarIngresoAsync(entrada);
            CustomResponse res = new()
            {
                Code = "1000",
                Message = "Mensaje "
            };
            return res;
        }
        #endregion Funcionalidad

    }
}
