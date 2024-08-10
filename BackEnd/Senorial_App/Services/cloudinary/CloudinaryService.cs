using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using IServices.Cloud;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using RequestResponseModels.Request.CloudinaryReq;
using RequestResponseModels.Response.CloudinaryRes;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using UtilitySecurity.CloudinarySetting;

namespace Services.cloudinary
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary _cloudinary;
        private readonly string _tempImagePath = Path.Combine(Path.GetTempPath(), "tempImages");

        public CloudinaryService()
        {
            // Cargar la configuración de Cloudinary
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var cloudName = configuration["Cloudinary:CloudName"];
            var apiKey = configuration["Cloudinary:ApiKey"];
            var apiSecret = configuration["Cloudinary:ApiSecret"];

            if (string.IsNullOrEmpty(cloudName) || string.IsNullOrEmpty(apiKey) || string.IsNullOrEmpty(apiSecret))
            {
                throw new ArgumentNullException("Cloudinary configuration values cannot be null or empty.");
            }

            var account = new Account(cloudName, apiKey, apiSecret);
            _cloudinary = new Cloudinary(account);

            // Crear la carpeta temporal si no existe
            if (!Directory.Exists(_tempImagePath))
            {
                Directory.CreateDirectory(_tempImagePath);
            }
        }

        public async Task<UploadImageResponse> UploadImageAsync(UploadImageRequest request)
        {
            // Guardar la imagen localmente
            string filePath = Path.Combine(_tempImagePath, request.FileName);
            await File.WriteAllBytesAsync(filePath, Convert.FromBase64String(request.ImageBase64));

            // Subir la imagen a Cloudinary desde el archivo guardado en una carpeta específica
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(filePath),
                PublicId = $"senorial_folder_img/{request.FileName}",
                Folder = "senorial_folder_img", // Carpeta específica en Cloudinary
                AccessMode = "public"
            };

            var result = await _cloudinary.UploadAsync(uploadParams);

            // Eliminar el archivo temporal después de subirlo
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            if (result.StatusCode == HttpStatusCode.OK)
            {
                return new UploadImageResponse
                {
                    PublicId = result.PublicId,
                    Url = result.SecureUrl.ToString(),
                    Success = true
                };
            }
            else
            {
                return new UploadImageResponse
                {
                    Success = false,
                    ErrorMessage = result.Error.Message
                };
            }
        }

    }
}