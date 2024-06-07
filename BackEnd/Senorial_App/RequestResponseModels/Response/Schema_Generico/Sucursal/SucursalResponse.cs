using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Schema_Generico.Sucursal
{
    public class SucursalResponse
    {
        public int IdSucursal { get; set; }
        public int IdAmbiente { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
        public int IdUbigeo { get; set; }
        public int IdDocumento { get; set; }
    }
}
