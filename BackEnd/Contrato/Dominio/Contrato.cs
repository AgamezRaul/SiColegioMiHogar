using BackEnd.Base;
using System;

namespace BackEnd.Contrato.Dominio
{
    public class Contrato : Entity<int>
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public double Sueldo { get; set; }
        public int IdDocente { get; set; }

        public Contrato(DateTime fechaInicio, DateTime fechaFin, double sueldo, int idDocente)
        {
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            Sueldo = sueldo;
            IdDocente = idDocente;
        }
    }
}