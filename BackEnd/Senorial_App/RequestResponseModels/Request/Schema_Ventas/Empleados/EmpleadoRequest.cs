using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Schema_Ventas.Empleados
{
    public class EmpleadoRequest
    {
        public int IdEmpleado { get; set; }
        public int IdRol { get; set; }
        public int IdPersona { get; set; }
        public int IdSucursal { get; set; }
    }
}
