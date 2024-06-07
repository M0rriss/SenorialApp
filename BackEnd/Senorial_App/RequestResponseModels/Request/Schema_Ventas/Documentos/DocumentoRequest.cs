using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Schema_Ventas.Documentos
{
    public class DocumentoRequest
    {
        public int IdDocumento { get; set; }
        [StringLength(100)]
        public string? NroDocumento { get; set; }
        public int IdComprobante { get; set; }
    }
}
