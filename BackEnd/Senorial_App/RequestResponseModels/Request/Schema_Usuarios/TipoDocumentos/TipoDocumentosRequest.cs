using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Schema_Usuarios.TipoDocumentos
{
    public class TipoDocumentosRequest
    {
        public int IdTipoDocumento { get; set; }

        [StringLength(100)]
        public string? Nombre { get; set; }
    }
}
