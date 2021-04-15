using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Periodo.Aplicacion.Request
{
    public class PeriodoResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Periodo Registrado Exitosamente");
        }
    }
}
