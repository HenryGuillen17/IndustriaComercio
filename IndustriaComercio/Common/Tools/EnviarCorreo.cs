using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Text.RegularExpressions;

namespace IndustriaComercio.Common.Tools
{
    public static class EnviarCorreo
    {
        private static SmtpClient ConfigurarEmail(string from)
        {
            var mensajeje = new MailMessage { From = new MailAddress(@from) };

            switch (mensajeje.From.Host)
            {
                case "gmail.com":
                    return new SmtpClient("smtp.gmail.com", 587);
                case "hotmail.com":
                case "hotmail.es":
                    return new SmtpClient("smtp.live.com", 25);
                case "yopmail.com":
                    return new SmtpClient("smtp.yopmail.com", 25);
                default:
                    return new SmtpClient("rut.colombiahosting.com.co", 465);
            }
        }


        public static bool ValidarEmail(string email)
        {
            const string expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                return Regex.Replace(email, expresion, string.Empty).Length == 0;
            }
            return false;
        }

        /// <summary>
        /// Enviar Correo
        /// </summary>
        /// <param name="from">Correo Desde donde se va a enviar</param>
        /// <param name="contraseña">Contraseña Desde donde se va a enviar<</param>
        /// <param name="to">Correr A donde se va a enviar<</param>
        /// <param name="asunto">Asunto del Correo</param>
        /// <param name="mensaje">Mensaje del Correo</param>
        /// <param name="rutaArchivosAdjuntos">Archivos Adjuntos</param>
        /// <param name="rutaImagenes">Imágenes adjuntas</param>
        public static void EnviarEmail(
            string from, 
            string contraseña, 
            IEnumerable<string> to, 
            string asunto,
            string mensaje, 
            IEnumerable<string> rutaArchivosAdjuntos,
            IEnumerable<Tuple<Stream, string>> archivosAdjuntosStream,
            IEnumerable<string> rutaImagenes
            )
        {
            MailMessage mensajeje = null;
            SmtpClient clienteSmtp = null;

            try
            {
                mensajeje = new MailMessage { From = new MailAddress(@from) };

                // Buscar smtp y puerto
                clienteSmtp = ConfigurarEmail(from);

                foreach (var adress in to)
                {
                    mensajeje.To.Add(adress);
                }

                // Add the file attachment to this e-mail message in the Body.
                if (rutaImagenes != null)
                    foreach (var ruta in rutaImagenes.Select((value, i) => new { i, value }))
                    {
                        //const string htmlBody = "<img src='cid:imagen' />";

                        var avHtml = AlternateView.CreateAlternateViewFromString
                            (mensaje, Encoding.UTF8, MediaTypeNames.Text.Html);


                        var inline = new LinkedResource(ruta.value, MediaTypeNames.Image.Jpeg)
                        {
                            ContentId = $"imagen{ruta.i}"
                        };

                        avHtml.LinkedResources.Add(inline);

                        mensajeje.AlternateViews.Add(avHtml);
                    }

                // Add the file attachment to this e-mail message.
                if (rutaArchivosAdjuntos != null)
                    foreach (var ruta in rutaArchivosAdjuntos)
                    {
                        mensajeje.Attachments.Add(new Attachment(ruta));
                    }
                if (archivosAdjuntosStream != null)
                    foreach (var tuple in archivosAdjuntosStream)
                    {
                        mensajeje.Attachments.Add(new Attachment(tuple.Item1, tuple.Item2));
                    }


                mensajeje.Subject = asunto;
                mensajeje.IsBodyHtml = true;
                mensajeje.Body = mensaje;

                clienteSmtp.EnableSsl = true;
                clienteSmtp.UseDefaultCredentials = false;
                clienteSmtp.Credentials = new NetworkCredential(from, contraseña);
                clienteSmtp.Send(mensajeje);
                mensajeje.Dispose();
                clienteSmtp.Dispose();
            }
            catch (Exception e)
            {
                try
                {
                    if (clienteSmtp == null) throw new NullReferenceException("el cliente smtp no puede ser null");

                    clienteSmtp.EnableSsl = false;
                    clienteSmtp.Send(mensajeje);
                    clienteSmtp.Dispose();

                    mensajeje.Dispose();
                }
                catch (Exception err)
                {
                    throw new NullReferenceException("No se pudo enviar el correo, error : " + err.Message);
                }
            }
        }

    }
}
