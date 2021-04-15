using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Mensualidad.Aplicacion.Request
{
   public class ActualizarMensualidadRequest
    {
        public int id { get; set; }
        //public int Mes { get; set; }
        public int DiaPago { get; set; }
        public DateTime FechaPago { get; set; }
        public double ValorMensualidad { get; set; }
        public double DescuentoMensualidad { get; set; }
        public double Abono { get; set; }
        public double Deuda { get => TotalMensualidad - Abono; }
        public string Estado { get => EstadoMensualiad(Deuda); }
        public double TotalMensualidad { get => ValorMensualidad - DescuentoMensualidad; }
        public string EstadoMensualiad(double debe)
        {
            if (debe > 0) { return "Mora"; }
            else { return "Paz y Salvo"; }
        }
    }

    public class ActualizarMensualidadResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Mensualidad Actualizada Exitosamente");
        }
    }
}
