using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Periodo.Aplicacion.Request
{
    
    public class PeriodoRequest
    {
        public int id { get; set; }
        public int NumeroPeriodo { get; set; }
        public string NombrePeriodo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}


