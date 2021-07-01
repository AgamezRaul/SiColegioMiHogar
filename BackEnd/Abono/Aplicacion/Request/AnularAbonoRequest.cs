using System;

namespace BackEnd.Abono.Aplicacion.Request
{
    public class AnularAbonoRequest
    {
        public int id { get; set; }
        public String EstadoAbono { get => "Anulado"; }
        public Double ValorAbono { get; set; }
        public int idMesualidad { get; set; }
    }
    public class AnularAbonoResponse
    {
        public AnularAbonoResponse(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Abono Anulado Exitosamente");
        }
    }
}
