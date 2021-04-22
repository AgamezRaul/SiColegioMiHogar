using BackEnd.Base;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace BackEnd.Mensualidad.Aplicacion.Service
{
    public class EviarEmailService
    {
        readonly IUnitOfWork _unitOfWork;
        public EviarEmailService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public MailMessage CrearEmailMensualidad()
        {
            MailMessage email = new MailMessage();
           // Attachment data = new Attachment(@"Mensualidad.pdf");
            email.To.Add("tatiana120849@gmail.com");
            email.From = new MailAddress("sicolegiomihogar@gmail.com");
            email.Subject = "Mesualidad" + DateTime.Now.ToString("dd/ MMM / yyy hh:mm:ss");
            email.Body = $"Estimado  : Padre de Familia \n se debe cominicar al colegio.";
            email.IsBodyHtml = true;
            email.Priority = MailPriority.Normal;
            //email.Attachments.Add(data);
            return email;
        }
        public SmtpClient ConfigurarSMTP()
        {
            //protocolo de acceso al servidor de correos
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            //aca toca poner un correo con su contraseña, ojo con eso manito.
            smtp.Credentials = new System.Net.NetworkCredential("sicolegiomihogar@gmail.com", "kqibngzvomoetukp");
            return smtp;
        }
        public string EnviarEmail()
        {
            string resultado = string.Empty;
            try
            {
                SmtpClient smtp = ConfigurarSMTP();
                MailMessage email = CrearEmailMensualidad();
                smtp.Send(email);
                email.Dispose();
                resultado = "Correo enviado";
            }
            catch (Exception er)
            {
                resultado = "Error enviando Correo electrónico: " + er.Message;
            }
            Console.WriteLine(resultado);
            return resultado;
        }
    }
}
