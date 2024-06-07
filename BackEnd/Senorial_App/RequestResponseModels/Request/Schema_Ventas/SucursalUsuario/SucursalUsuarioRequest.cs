using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Schema_Ventas.SucursalUsuario
{
    public class SucursalUsuarioRequest
    {
        public int IdSucursal { get; set; }
        public int IdUsuario { get; set; }
        [StringLength(100)]
        public string? Descripcion { get; set; }
    }
}
