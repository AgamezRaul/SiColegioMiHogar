using BackEnd.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Actividad
{
    public class Actividad : Entity<int>
    {
        public string Descripcion { get; set; }
        public double Porcentaje { get; set; }
        public int IdMateria { get; set; }
        public int IdPeriodo { get; set; }

        public Actividad(string descripcion, double porcentaje, int idMateria, int idPeriodo)
        {
            Descripcion = descripcion;
            Porcentaje = porcentaje;
            IdMateria = idMateria;
            IdPeriodo = idPeriodo;
        }
    }
}
