using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Mensualidad.Aplicacion.Request
{
   public class CrearMensualidadRequest
    {
        public int id { get; set; }
        public int Mes { get; set; }
        public int DiaPago { get; set; }
        public DateTime FechaPago { get; set; }
        public double ValorMensualidad { get; set; }
        public double DescuentoMensualidad { get; set; }
        public double Abono { get; set; }
        public double Deuda { get => TotalMensualidad - Abono; }
        public string Estado { get => EstadoMensualiad(Deuda); }
        public int IdMatricula { get; set; }
        public double TotalMensualidad { get => ValorMensualidad - DescuentoMensualidad; }
        public string EstadoMensualiad(double debe)
        {
            if (debe > 0) { return "Mora"; }
            else { return "Paz y Salvo"; }
        }
        public IReadOnlyList<string> CanCrear(CrearMensualidadRequest mensualidad)
        {
            var errors = new List<string>();

            if (mensualidad.Mes == 0)
                errors.Add("Campo Mes en que se realiza el pago vacio");
            if (mensualidad.DiaPago == 0)
                errors.Add("Campo dia de pago en el que se acordo pagar la mensualidad  vacio");
            if (string.IsNullOrEmpty(mensualidad.FechaPago.ToString()))
                errors.Add("Campo Fecha de Pago vacio");
            if (mensualidad.ValorMensualidad == 0)
                errors.Add("Campo  Valor de Mensualidad vacio");
            if (mensualidad.DescuentoMensualidad < 0)
                errors.Add("Campo Descuento Mensualidad no debe ser negativo");
            if (mensualidad.Abono == 0)
                errors.Add("Campo Abono vacio");
            if (string.IsNullOrEmpty(mensualidad.Estado))
                errors.Add("Campo Estado de mensualidad vacio");
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
