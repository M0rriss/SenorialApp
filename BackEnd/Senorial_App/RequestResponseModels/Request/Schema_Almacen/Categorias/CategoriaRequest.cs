using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Schema_Almacen.Categorias
{
    public class CategoriaRequest
    {
        public int IdCategoria { get; set; }

        [StringLength(100)]
        public string Nombre { get; set; }

        public int? IdCategoriaPadre { get; set; }
    }
}
