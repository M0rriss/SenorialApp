using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSenorialModels.View.Almacen.DetalleIngreso
{
    public class VwBuscarInsumoDetalle
    {
        public int IdInsumo { get; set; }
        public int IdInventario { get; set; }
        public string? Nombre { get; set; } = string.Empty;
        public int StockTotal { get; set; }

    }
}
