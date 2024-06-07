using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Schema_Ventas.SucursalUsuario
{
    public class SucursalUsuarioResponse
    {
        public int IdSucursal { get; set; }
        public int IdUsuario { get; set; }
        public string? Descripcion { get; set; }
    }
}
