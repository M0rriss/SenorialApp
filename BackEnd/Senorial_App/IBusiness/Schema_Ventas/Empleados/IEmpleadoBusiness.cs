using IBusiness.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Ventas.Empleados;
using RequestResponseModels.Response.Schema_Ventas.Empleados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Schema_Ventas.Empleados
{
    public interface IEmpleadoBusiness : ICrudBusiness<EmpleadoRequest, EmpleadoResponse>
    {
        public List<EmpleadoUiRequest> UiGetEmpleado();
    }
}
