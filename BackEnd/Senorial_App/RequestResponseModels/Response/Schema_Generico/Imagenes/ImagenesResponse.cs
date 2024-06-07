using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Schema_Generico.Imagenes
{
    public class ImagenesResponse
    {
        public int IdImg { get; set; }
        public string? Url { get; set; }
        public string? Nombre { get; set; }
    }
}
