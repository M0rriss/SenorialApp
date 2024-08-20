using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Schema_Ventas.Productos
{
    public class ProductEditDashRequest
    {
        private int _idProducto = 0;
        private IFormFile ? _file = null!;
        private string _nombre = string.Empty;
        private string _description = string.Empty;
        private int _idCategoria = 0;
        private string _imprimir = string.Empty;
        private decimal _precioCompra = 0m;

        public int IdProducto { get => _idProducto; set => _idProducto = value; }
        public IFormFile? File { get => _file; set => _file = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Description { get => _description; set => _description = value; }
        public int IdCategoria { get => _idCategoria; set => _idCategoria = value; }
        public string Imprimir { get => _imprimir; set => _imprimir = value; }
        public decimal PrecioCompra { get => _precioCompra; set => _precioCompra = value; }
        public bool Nuevo { get; set; } = false;
    }
}
