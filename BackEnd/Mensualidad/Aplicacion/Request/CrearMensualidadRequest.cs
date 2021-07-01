using System;
using System.Collections.Generic;

namespace BackEnd.Mensualidad.Aplicacion.Request
{
    public class CrearMensualidadRequest
    {
        public int id { get; set; }
        public String Mes { get; set; }
        public double Deuda { get; set; }
        public string Estado { get => EstadoMensualiad(Deuda); }
        public int Año { get => DateTime.Now.Year; }
        public int IdMatricula { get; set; }
        public string EstadoMensualiad(double debe)
        {
            if (debe > 0) { return "Mora"; }
            else { return "Paz y Salvo"; }
        }
        public IReadOnlyList<string> CanCrear(CrearMensualidadRequest mensualidad)
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(mensualidad.Mes))
                errors.Add("Campo Mes en que se realiza el pago vacio");
            if (mensualidad.IdMatricula == 0)
                errors.Add("Campo identiificacion  de matricula  vacio");
            return errors;
        }
    }
    public class CrearMensualidadResponse
    {
        public CrearMensualidadResponse(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Mensualidad Creada Exitosamente");
        }
    }

}
