using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.CloudinaryReq
{
    public class UploadImageRequest
    {
        public string ImageBase64 { get; set; }  // Base64 string of the image
        public string FileName { get; set; }
    }
}
