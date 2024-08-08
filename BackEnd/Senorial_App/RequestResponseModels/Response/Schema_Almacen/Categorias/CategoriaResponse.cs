using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Schema_Almacen.Categorias
{
    public class CategoriaResponse
    {
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public int? IdCategoriaPadre { get; set; }
        public bool Estado { get; set; }
        public string EstadoDescripcion => Estado ? "Activo" : "Inactivo";
        public class CategoriaUiResponse
        {
            public string Categoria { get; set; }
            public string Subcategorias { get; set; }
            public string Estado { get; set; }
        }
    }
}
