using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Periodo.Aplicacion.Request
{
    
    public class CrearPeriodoRequest
    {
        public int Id { get; set; }
        public string NombrePeriodo { get; set; }
        public int NumeroPeriodo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
    public class CrearPeriodoResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Periodo Registrado Exitosamente");
        }
    }
}


