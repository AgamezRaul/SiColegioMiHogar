using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Periodo.Aplicacion.Request
{
    
    public class PeriodoRequest
    {
	   public string NombrePeriodo { get; set; }
           public int NumeroPeriodo { get; set; }
           public DateTime FechaInicio { get; set; }
	   public DateTime FechaFin { get; set; }
    }
}


