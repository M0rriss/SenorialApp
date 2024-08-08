using RequestResponseModels.Request.CloudinaryReq;
using RequestResponseModels.Response.CloudinaryRes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices.Cloud
{
    public interface ICloudinaryService
    {
        Task<UploadImageResponse> UploadImageAsync(UploadImageRequest request);

    }
}
