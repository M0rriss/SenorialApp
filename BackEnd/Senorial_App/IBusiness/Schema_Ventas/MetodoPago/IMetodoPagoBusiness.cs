using IBusiness.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Ventas.MetodoPago;
using RequestResponseModels.Response.Schema_Ventas.MetodoPago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RequestResponseModels.Request.Schema_Ventas.MetodoPago.MetodoPagoRequest;

namespace IBusiness.Schema_Ventas.MetodoPago
{
    public interface IMetodoPagoBusiness : ICrudBusiness<MetodoPagoRequest, MetodoPagoResponse>
    {
        #region UI Methods
        Task<List<MetodoPagoUiResponse>> UiGetMetodoPago();
        Task<MetodoPagoUiResponse> InsertUiMetodoPago(MetodoPagoUiRequest request);
        Task<MetodoPagoUiResponse> UpdateUiMetodoPago(MetodoPagoUpdateUiRequest request);
        Task<bool> DeleteUiMetodoPago(int id);
        #endregion
    }
}
