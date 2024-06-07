using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Schema_Ventas.Productos
{
    public class ProductoRequest
    {
        public int IdProducto { get; set; }
        [StringLength(100)]
        public string? Nombre { get; set; }
        [StringLength(100)]
        public string? Descripcion { get; set; }
        [StringLength(100)]
        public string Derivar { get; set; }
        public int IdImg { get; set; }
    }
}
