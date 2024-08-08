using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.CloudinaryRes
{
    public class UploadImageResponse
    {
        public string PublicId { get; set; } 
        public string Url { get; set; }     
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
}
