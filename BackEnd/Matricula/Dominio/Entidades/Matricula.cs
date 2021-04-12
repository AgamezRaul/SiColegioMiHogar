using BackEnd.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Matricula.Dominio
{
    public class Matricula : Entity<int>
    {
       
        public DateTime FecConfirmacion { get; set; }
        public int IdePreMatricula { get; set; }
        public Matricula( DateTime fecConfirmacion, int idePreMatricula)
        {
            FecConfirmacion = fecConfirmacion;
            IdePreMatricula = idePreMatricula;
        }
        public IReadOnlyList<string> CanCrear(Matricula matricula)
        {
            var errors = new List<string>();
           
            if (string.IsNullOrEmpty(matricula.FecConfirmacion.ToString()))
                errors.Add("Campo Fecha de confirmacion vacio");
            if (matricula.IdePreMatricula == 0)
                errors.Add("Campo identiificacion  de Pre-matricula  vacio");
            return errors;
        }
    }
}
