using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;

        public EmailService()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("cbcd484297b4e0", "02edf98db75f31");
            server.EnableSsl = true;
            server.Port = 2525;
            server.Host = "sandbox.smtp.mailtrap.io";
        }

        public void armarCorreo(string emailDestino, string asunto, string mensaje)
        {
            email = new MailMessage();
            email.From = new MailAddress("gestioncomercio12@gmail.com");
            email.To.Add(emailDestino);
            email.Subject = asunto;
            email.IsBodyHtml = true;
            email.Body = mensaje;
        }

        public void enviarEmail()
        {
            try
            {
                server.Send(email);

            }catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
