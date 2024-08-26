using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Schema_Ventas.Productos
{
    public class ProductoResponse
    {
        public int IdProducto { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string Derivar { get; set; }
        public int IdImg { get; set; }
    }
    public class ProductoUiResponse
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Derivar { get; set; }
        public decimal Precio { get; set; }
        public string Categoria { get; set; }
    }
}
