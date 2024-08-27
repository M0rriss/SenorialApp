using CommonModels.Common;
using DBSenorialModels.Senorial;
using IBusiness.Schema_Produccion.Salidas;
using IRepository.Schema_Produccion.Salidas;
using Microsoft.AspNetCore.Http.Timeouts;
using Repository.Schema_Produccion.Salidas;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Request.Schema_Produccion.Salidas;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Produccion.Salidas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Schema_Produccion.Salidas
{
    public class SalidaBusiness : ISalidaBusiness
    {
        private readonly ISalidaRepository _salidaRepository;
        public SalidaBusiness()
        {
            _salidaRepository = new SalidaRepository();
        }
        public Task<SalidaResponse> Create(SalidaRequest entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<SalidaResponse>> CreateMultiple(List<SalidaRequest> list)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<SalidaRequest>> DeleteMultiple(List<SalidaRequest> list)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<List<SalidaResponse>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<GenericFilterResponse<SalidaResponse>> GetByFilterAsync(GenericFilterRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<SalidaResponse> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SalidaResponse> Update(SalidaRequest entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<SalidaResponse>> UpdateMultiple(List<SalidaRequest> list)
        {
            throw new NotImplementedException();
        }

        #region Funcionalida
        public async Task<CustomResponse> RegistarSalidaAsync(SalidaRequest req)
        {
            Salida salida = new()
            {
                IdInsumo = req.IdInsumo,
                IdInventario = req.IdInventario,
                FechaSalida = DateTime.Now,
                Cantidad = req.Cantidad,
                SucursalIdSucursal = 1,
                Motivo = req.Motivo,

            };
            await _salidaRepository.RegistrarSalidaAsync(salida);
            CustomResponse res = new()
            {
                Code = "1000",
                Message = "Se registro la salida",
            };
            return res;
        }
        #endregion Funcionalida

    }
}
