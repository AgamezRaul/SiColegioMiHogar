using System;

namespace BackEnd.ValorMensualidad.Aplicacion.Request
{
    public class ActualizarValorMensualidadRequest
    {
        public int id { get; set; }
        public DateTime Fecha { get; set; }
        public int Año { get => Fecha.Year; }
        public Double PrecioMensualidad { get; set; }

    }
    public class ActualizarValorMensualidadResponse
    {
        public ActualizarValorMensualidadResponse(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Valor Mensualidad Actualizada Exitosamente");
        }
    }
}
