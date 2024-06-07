using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Schema_Generico.Imagenes
{
    public class ImagenesRequest
    {
        public int IdImg { get; set; }
        public string? Url { get; set; }
        [StringLength(100)]
        public string? Nombre { get; set; }
    }
}
