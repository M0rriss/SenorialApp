using DBSenorialModels.Senorial;
using IServices.Gmail;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RequestResponseModels.Request.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using UtilitySecurity.OneTimePassword;

namespace Services.Gmail
{
    public class SendEmailWithGoogleSMTP : EmailSettings, ISendEmailSmtp
    {
        private readonly OtpGenerator _otpGenerator;
        //private readonly Dictionary<string, OtpData> _otpStorage;

        public SendEmailWithGoogleSMTP()
        {
            _otpGenerator = new OtpGenerator();
            //_otpStorage = new Dictionary<string, OtpData>();
        }

        // Método para enviar el correo electrónico con el código OTP
        public async Task SendEmail(string destino, string codigo = null)
        {
            // Generar el código OTP si no se proporciona uno
            string codigoOtp = string.IsNullOrEmpty(codigo) ? _otpGenerator.GenerateOtp() : codigo;

            //// Almacenar el código OTP con su expiración (5 minutos)
            //DateTime expirationTime = DateTime.UtcNow.AddMinutes(5);
            //_otpStorage[destino] = new OtpData { Otp = codigoOtp, ExpirationTime = expirationTime };

            // Construir el correo electrónico
            using (var mail = new MailMessage())
            using (var smtpClient = new SmtpClient(SmtpServer, SmtpPort))
            {

                mail.From = new MailAddress(SenderEmail, SenderName);
                mail.To.Add(destino);
                mail.Subject = "Restaurar Contraseña";
                mail.Body = $@"
                    <html lang=""es"">
                    <head>
                        <meta charset=""UTF-8"">
                        <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                        <title>Recuperación de Contraseña - Señorial</title>
                    </head>
                    <body style=""font-family: Arial, sans-serif; background-color: #f0f0f0; padding: 20px;"">
                        <div style=""max-width: 500px; margin: 0 auto; background-color: #ffffff; padding: 20px; border-radius: 8px; box-shadow: 0 0 10px rgba(0,0,0,0.1);"">
                            <div style=""text-align: center;"">
                                <img src=""https://res.cloudinary.com/dilxrtdwx/image/upload/fl_preserve_transparency/v1723063595/senorial_folder_img/senorial_folder_img/2d207588-83b8-4f94-98f7-644f2490f765_SenorialLogoBW.svg.jpg?_s=public-apps"" alt=""Señorial Logo"" style=""max-width: 100px; height: auto; margin-bottom: 10px;"">
                            </div>
                            <h2 style=""color: #FF910F; text-align: center; margin-top: 5px;"">Recuperación de Contraseña</h2>
                            <p>Correo {destino},</p>
                            <p>Has solicitado recuperar tu contraseña de Señorial. Utiliza el siguiente código de verificación para continuar:</p>
                            <p style=""text-align: center; font-size: 2em; margin-top: 20px; font-weight: bold; color: #333333;"">
                                <span style=""border: 1px solid #ccc; padding: 10px 20px; border-radius: 5px;"">{codigoOtp}</span>
                            </p>
                            <p style=""text-align: center;"">Si no solicitaste este cambio, por favor ignora este correo.</p>
                            <p style=""text-align: center;"">¡Gracias por utilizar Señorial!</p>
                            <p style=""font-size: 0.8em; color: #999999; text-align: center;"">Este es un correo generado automáticamente, por favor no respondas a este mensaje.</p>
                        </div>
                    </body>
                    </html>";
                mail.IsBodyHtml = true;

                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(SmtpUsername, SmtpPassword);
                smtpClient.EnableSsl = EnableSsl;

                await smtpClient.SendMailAsync(mail);
            }

            // Método para validar el código OTP recibido
            //public bool ValidateOtp(string destino, string codigoOtp)
            //{
            //    if (_otpStorage.TryGetValue(destino, out var otpData))
            //    {
            //        // Verificar si el código OTP coincide y no ha expirado
            //        if (otpData.Otp == codigoOtp && otpData.ExpirationTime > DateTime.UtcNow)
            //        {
            //            // Limpiar el código OTP después de usarlo
            //            _otpStorage.Remove(destino);
            //            return true;
            //        }
            //    }
            //    return false;
            //} Analizar mas adelante
        }
    }
}