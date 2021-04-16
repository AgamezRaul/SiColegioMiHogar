using BackEnd.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Periodo.Dominio
{
    public class Periodo : Entity<int>
    {
  
        public int NumeroPeriodo { get; set; }
        public string NombrePeriodo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
       
        public Periodo()
        {

        }

        public Periodo(int NumeroPeriodo, string NombrePeriodo, DateTime FechaInicio, DateTime FechaFin)
        {
            this.FechaFin = FechaFin;
            this.FechaInicio = FechaInicio;
            this.NumeroPeriodo = NumeroPeriodo;
            this.NombrePeriodo = NombrePeriodo;
        }

        public IReadOnlyList<string> CanCrear(Periodo periodo)
        {
            var errors = new List<string>();

            
            if (periodo.NumeroPeriodo == 0)
                errors.Add("Campo Numero de Periodo vacio");
            if (string.IsNullOrEmpty(periodo.NombrePeriodo))
                errors.Add("Campo Nombre de Periodo vacio");
            if (string.IsNullOrEmpty(periodo.FechaInicio.ToString()))
                errors.Add("Campo Fecha de Inicio vacio");
            if (string.IsNullOrEmpty(periodo.FechaFin.ToString()))
                errors.Add("Campo Fecha de Inicio vacio");
            
            return errors;
        }

    }
}
