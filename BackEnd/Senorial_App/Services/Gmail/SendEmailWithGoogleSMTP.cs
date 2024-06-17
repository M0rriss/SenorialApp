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

        OtpGenerator otp;
        MailMessage mail;
        SmtpClient smtp;
        public SendEmailWithGoogleSMTP()
        {
            mail = new();
            smtp = new();
            otp = new();
        }

        //public Task SendEmail(string destino)
        //{
        //    EmailSettings request = new();
        //    string codigo = otp.GenerateOtp();
        //    mail.From = new(SenderEmail);
        //    mail.To.Add(destino);
        //    mail.Subject = "Restaurar Contraseña";
        //    mail.Body = $@"
        //    <html lang=""es"">
        //    <head>
        //        <meta charset=""UTF-8"">
        //        <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
        //        <title>Recuperación de Contraseña - Señorial</title>
        //    </head>
        //    <body style=""font-family: Arial, sans-serif; background-color: #f0f0f0; padding: 20px;"">
        //        <div style=""max-width: 600px; margin: 0 auto; background-color: #ffffff; padding: 20px; border-radius: 8px; box-shadow: 0 0 10px rgba(0,0,0,0.1);"">
        //            <img src=""https://logo.png"" alt=""Señorial Logo"" style=""max-width: 100%; height: auto; margin-bottom: 20px;"">
        //            <h2 style=""color: #FF910F;"">Recuperación de Contraseña</h2>
        //            <p>Correo {destino},</p>
        //            <p>Has solicitado recuperar tu contraseña de Señorial. Utiliza el siguiente código de verificación para continuar:</p>
        //            <p style=""text-align: center; font-size: 2em; margin-top: 20px; font-weight: bold; color: #333333;"">
        //                <span style=""border: 1px solid #ccc; padding: 10px 20px; border-radius: 5px;"">{codigo}</span>
        //            </p>
        //            <p>Si no solicitaste este cambio, por favor ignora este correo.</p>
        //            <p>¡Gracias por utilizar Señorial!</p>
        //            <p style=""font-size: 0.8em; color: #999999;"">Este es un correo generado automáticamente, por favor no respondas a este mensaje.</p>
        //        </div>
        //    </body>
        //    </html>";
        //    mail.IsBodyHtml = true;
        //    smtp.Credentials = new NetworkCredential(SmtpUsername, SmtpPassword);
        //    smtp.EnableSsl = EnableSsl;
        //    smtp.UseDefaultCredentials = false;
        //    smtp.Port = SmtpPort;
        //    smtp.Host = SmtpServer;

        //    //await smtpClient.SendMailAsync(mail);
        //   return request
        //}
        public async Task SendEmail(string destino)
        {
            string codigo = otp.GenerateOtp();

            using (var mail = new MailMessage())
            using (var smtpClient = new SmtpClient(SmtpServer,SmtpPort))
            {
                mail.From = new MailAddress(SenderEmail,SenderName);
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
                <div style=""max-width: 600px; margin: 0 auto; background-color: #ffffff; padding: 20px; border-radius: 8px; box-shadow: 0 0 10px rgba(0,0,0,0.1);"">
                    <img src=""https://logo.png"" alt=""Señorial Logo"" style=""max-width: 100%; height: auto; margin-bottom: 20px;"">
                    <h2 style=""color: #FF910F;"">Recuperación de Contraseña</h2>
                    <p>Correo {destino},</p>
                    <p>Has solicitado recuperar tu contraseña de Señorial. Utiliza el siguiente código de verificación para continuar:</p>
                    <p style=""text-align: center; font-size: 2em; margin-top: 20px; font-weight: bold; color: #333333;"">
                        <span style=""border: 1px solid #ccc; padding: 10px 20px; border-radius: 5px;"">{codigo}</span>
                    </p>
                    <p>Si no solicitaste este cambio, por favor ignora este correo.</p>
                    <p>¡Gracias por utilizar Señorial!</p>
                    <p style=""font-size: 0.8em; color: #999999;"">Este es un correo generado automáticamente, por favor no respondas a este mensaje.</p>
                </div>
            </body>
            </html>";
                mail.IsBodyHtml = true;

                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(SmtpUsername,SmtpPassword);
                smtpClient.EnableSsl = EnableSsl;

                await smtpClient.SendMailAsync(mail);

            }
        }

    }
}
