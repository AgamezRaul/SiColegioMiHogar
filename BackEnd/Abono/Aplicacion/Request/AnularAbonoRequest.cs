using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Abono.Aplicacion.Request
{
    public class AnularAbonoRequest
    {
        public int id { get; set; }
        public String EstadoAbono { get => "Anulado"; }
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
