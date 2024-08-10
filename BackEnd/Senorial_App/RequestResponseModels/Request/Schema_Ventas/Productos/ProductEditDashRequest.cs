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
        private IFormFile _file = null!;
        private int _idProducto = 0;
        private string _nombre = string.Empty;
        private string _description = string.Empty;
        private int _idCategoria = 0;
        private string _inprimir = string.Empty;
        private decimal _pricioCompra = 0m;

        public IFormFile File { get => _file; set => _file = value; }
        public int IdProducto { get => _idProducto; set => _idProducto = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Description { get => _description; set => _description = value; }
        public int IdCategoria { get => _idCategoria; set => _idCategoria = value; }
        public string Inprimir { get => _inprimir; set => _inprimir = value; }
        public decimal PricioCompra { get => _pricioCompra; set => _pricioCompra = value; }

        public bool Nuevo { get; set; } = false;
    }
}
