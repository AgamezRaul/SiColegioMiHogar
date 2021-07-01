using System;

namespace BackEnd.Abono.Aplicacion.Request
{
    public class ActualizarAbonoRequest
    {
        public int id { get; set; }
        public Double ValorAbono { get; set; }
        public int idMesualidad { get; set; }

    }
    public class ActualizarAbonoResponse
    {
        public ActualizarAbonoResponse(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Abono Actualizado Exitosamente");
        }
    }
}
