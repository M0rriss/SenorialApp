using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Schema_Generico.Ubigeo
{
    public class UbigeoRequest
    {
        public int IdUbigeo { get; set; }
        [StringLength(12)]
        public string? Codigo { get; set; }
        [StringLength(100)]
        public string? Distrito { get; set; }
        [StringLength(100)]
        public string? Provincia { get; set; }
        [StringLength(100)]
        public string? Departamento { get; set; }
    }
}
