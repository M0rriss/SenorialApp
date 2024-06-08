using IBusiness.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Ventas.Voucher;
using RequestResponseModels.Response.Schema_Ventas.Voucher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Schema_Ventas.Voucher
{
    public interface IVoucherBusiness : ICrudBusiness<VoucherRequest, VoucherResponse>
    {
    }
}
