using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Schema_Ventas.Documentos
{
    public class DocumentoResponse
    {
        public int IdDocumento { get; set; }
        public string? NroDocumento { get; set; }
        public int IdComprobante { get; set; }
    }
}
