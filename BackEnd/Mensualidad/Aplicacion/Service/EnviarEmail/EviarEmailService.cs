using BackEnd.Base;
using BackEnd.Mensualidad.Aplicacion.Request;
using System;
using System.Net.Mail;

namespace BackEnd.Mensualidad.Aplicacion.Service
{
    public class EviarEmailService
    {

        readonly IUnitOfWork _unitOfWork;
        public EviarEmailService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public MailMessage CrearEmailMensualidad(CrearMensualidadRequest request, string correo)
        {
            MailMessage email = new MailMessage();
            email.To.Add(correo);
            email.From = new MailAddress("sicolegiomihogar@gmail.com");
            email.Subject = "Mesualidad en Mora, Notificado el dia: " + DateTime.Now.ToString("dd/ MMM / yyy hh:mm:ss");
            email.Body = $"Estimado  : Padre de Familia el Colegio MiHogar le comuica que se encunetra en {request.Estado}\n Por el mes: {request.Mes} " +
            $"\n con una deuda de {request.Deuda} \n Por Favor acerquese a las intalaciones del colegio mi Hogar";
            email.IsBodyHtml = true;
            email.Priority = MailPriority.Normal;
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
        public string EnviarEmail(CrearMensualidadRequest request, string correo)
        {
            string resultado = string.Empty;
            try
            {
                SmtpClient smtp = ConfigurarSMTP();
                MailMessage email = CrearEmailMensualidad(request, correo);
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
