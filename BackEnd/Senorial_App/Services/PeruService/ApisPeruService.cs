using CloudinaryDotNet;
using Newtonsoft.Json;
using RequestResponseModels.Response.ApisPeru;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using IServices.PeruService;

namespace Services.PeruService
{
    public  class ApisPeruService : IApisPeruService
    {
        public async Task<DniResponse> BuscarDni(string dni)
        {
            string ruta = "https://dniruc.apisperu.com/api/v1/dni/##DNI##?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJlbWFpbCI6Imd1dGllcnJlem1hdXJpY2lvMTExMTFAZ21haWwuY29tIn0.g9QyjLXxNLEi4ZQdybLvsbtebuwneQBSy7T1_2S_B-A";
            ruta = ruta.Replace("##DNI##", dni);
            DniResponse? res = new();
            using (HttpClient client = new HttpClient())
            {
                //con la seguridad de C#
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                static bool value(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                { return true; }
#pragma warning disable CS8622 // La nulabilidad de los tipos de referencia del tipo de parámetro no coincide con el delegado de destino (posiblemente debido a los atributos de nulabilidad).
                ServicePointManager.ServerCertificateValidationCallback = value;
#pragma warning restore CS8622 // La nulabilidad de los tipos de referencia del tipo de parámetro no coincide con el delegado de destino (posiblemente debido a los atributos de nulabilidad).

                using (HttpResponseMessage response = client.GetAsync(ruta).Result)
                {
                    if (response.StatusCode == HttpStatusCode.OK)//200
                    {
                        string jsonResult = await response.Content.ReadAsStringAsync();
                        res = JsonConvert.DeserializeObject<DniResponse>(jsonResult);
                    }
                    else
                    {
                        throw new Exception(message: "Comunicarse con sistemas");
                        //VAMOS A MANEJAR UN CONTROL DE ERRORES
                    }
                }
            }
            if (res == null)
            {
                throw new ArgumentException(message: "no se encontro el dni");
            }
            return res;
        }
        public async Task<RucResponse> BuscarRuc(string ruc)
        {
            string url = "https://dniruc.apisperu.com/api/v1/ruc/##RUC##?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJlbWFpbCI6Imd1dGllcnJlem1hdXJpY2lvMTExMTFAZ21haWwuY29tIn0.g9QyjLXxNLEi4ZQdybLvsbtebuwneQBSy7T1_2S_B-A";
            url = url.Replace("##RUC##", ruc);
            RucResponse? res = new();
            using (HttpClient client = new HttpClient())
            {
                //con la seguridad de C#
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                static bool value(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                { return true; }
#pragma warning disable CS8622 // La nulabilidad de los tipos de referencia del tipo de parámetro no coincide con el delegado de destino (posiblemente debido a los atributos de nulabilidad).
                ServicePointManager.ServerCertificateValidationCallback = value;
#pragma warning restore CS8622 // La nulabilidad de los tipos de referencia del tipo de parámetro no coincide con el delegado de destino (posiblemente debido a los atributos de nulabilidad).

                using (HttpResponseMessage response = client.GetAsync(url).Result)
                {
                    if (response.StatusCode == HttpStatusCode.OK)//200
                    {
                        string jsonResult = await response.Content.ReadAsStringAsync();
                        res = JsonConvert.DeserializeObject<RucResponse>(jsonResult);
                    }
                    else
                    {
                        throw new Exception(message: "Comunicarse con sistemas");
                        //VAMOS A MANEJAR UN CONTROL DE ERRORES
                    }
                }
            }
            if (res == null)
            {
                throw new Exception(message: "no se encontro el ruc");
            }
            return res;
        }

    }
}
