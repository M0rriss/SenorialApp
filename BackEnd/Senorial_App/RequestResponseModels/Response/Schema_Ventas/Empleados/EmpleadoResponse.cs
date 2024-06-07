using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Schema_Ventas.Empleados
{
    public class EmpleadoResponse
    {
        public int IdEmpleado { get; set; }
        public int IdRol { get; set; }
        public int IdPersona { get; set; }
        public int IdSucursal { get; set; }
    }
}
