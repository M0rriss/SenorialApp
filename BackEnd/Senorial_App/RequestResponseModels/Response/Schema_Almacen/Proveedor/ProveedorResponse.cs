using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Schema_Almacen.Proveedor
{
    public class ProveedorResponse
    {
        public int IdProveedor { get; set; }
        public int IdPersona { get; set; }
        public string? Vende { get; set; }
    }
}
