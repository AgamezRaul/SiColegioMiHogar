using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Mensualidad.Aplicacion.Request
{
   public class EliminarMensualidadRequest
    {
        public int IdMensualidad { get; set; }
    }
    public class EliminarMensualidadResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Mensualidad Eliminada Exitosamente");
        }
    }
}
