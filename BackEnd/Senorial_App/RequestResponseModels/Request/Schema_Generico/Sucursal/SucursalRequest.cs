using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Schema_Generico.Sucursal
{
    public class SucursalRequest
    {
        public int IdSucursal { get; set; }
        public int IdAmbiente { get; set; }
        [StringLength(100)]
        public string? Nombre { get; set; }
        [StringLength(200)]
        public string? Direccion { get; set; }
        public int IdUbigeo { get; set; }
        public int IdDocumento { get; set; }
    }
}
