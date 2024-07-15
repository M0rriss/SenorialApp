using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Schema_Ventas.Mesas
{
    public class MesaRequest
    {
        //public int IdMesa { get; set; }
        [StringLength(100)]
        public string? Nombre { get; set; }
        public string Estado { get; set; }
    }
    public class MesaUpdateRequest
    {
        public int IdMesa { get; set; }
        [StringLength(100)]
        public string? Nombre { get; set; }
        public string Estado { get; set; }
    }
}
