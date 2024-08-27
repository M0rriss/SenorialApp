using DBSenorialModels.Senorial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSenorialModels.View.Almacen
{
    public class VwDetalleIngreos
    {
        public int idInventario { get; set; }
        public string Insumo { get; set; } = string.Empty;
        public int Stock { get; set; }
        public DateTime Fecha { get; set; }
        public string UnidadMedida { get; set; } =string.Empty;
        public string Tipo { get; set;} =string.Empty;
    }
}
