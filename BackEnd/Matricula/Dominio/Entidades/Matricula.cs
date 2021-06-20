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
        public double ValorMatricula { get; set; }

        public Matricula(DateTime fecConfirmacion, int idePreMatricula, double valorMatricula)
        {
            FecConfirmacion = fecConfirmacion;
            IdePreMatricula = idePreMatricula;
            ValorMatricula = valorMatricula;
        }
    }
}
