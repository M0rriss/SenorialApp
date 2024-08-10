using IBusiness.Schema_Generico.CRUD;
using Microsoft.AspNetCore.Http;
using RequestResponseModels.Request.CloudinaryReq;
using RequestResponseModels.Request.Schema_Generico.Imagenes;
using RequestResponseModels.Response.CloudinaryRes;
using RequestResponseModels.Response.Schema_Generico.Imagenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Schema_Generico.Imagenes
{
    public interface IImagenesBusiness : ICrudBusiness<ImagenesRequest, ImagenesResponse>
    {
        Task<UploadImageResponse> UploadImageAsync(UploadImageRequest request);
        Task<UploadImageResponse> SubirImagenAsync(IFormFile file);
    }
}
