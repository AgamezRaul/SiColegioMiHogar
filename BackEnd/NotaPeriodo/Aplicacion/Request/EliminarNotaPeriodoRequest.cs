using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.NotaPeriodo.Aplicacion.Request
{
    public class EliminarNotaPeriodoRequest
    {
        public int IdNotaPeriodo { get; set; }
    }
    public class EliminarNotaPeriodoResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Nota Periodo Eliminado Exitosamente");
        }
    }
}
