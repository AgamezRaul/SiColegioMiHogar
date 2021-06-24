using BackEnd.Base;
using System;

namespace BackEnd.Mensualidad.Dominio
{
    public class Mensualidad : Entity<int>
    {
        public String Mes { get; set; }
        public double Deuda { get; set; }
        public string Estado { get; set; }
        public int Año { get; set; }
        public int IdMatricula { get; set; }
        public Mensualidad(string mes, double deuda, string estado, int año, int idMatricula)
        {
            Mes = mes;
            Deuda = deuda;
            Estado = estado;
            Año = año;
            IdMatricula = idMatricula;
        }

    }
}
