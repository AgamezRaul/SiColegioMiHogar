using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Nota.Aplicacion.Request
{
   
    public class NotaResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Nota Registrada Exitosamente");
        }
    }
}
