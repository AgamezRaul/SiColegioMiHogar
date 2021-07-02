using BackEnd.Base;
using System;

namespace BackEnd.Abono.Dominio
{
    public class Abono : Entity<int>
    {
        public int Mes { get; set; }
        public DateTime FechaPago { get; set; }
        public Double ValorAbono { get; set; }
        public String EstadoAbono { get; set; }
        public int IdMensualidad { get; set; }
        public Abono(int mes, DateTime fechaPago, double valorAbono, String estadoAbono, int idMensualidad)
        {
            Mes = mes;
            FechaPago = fechaPago;
            ValorAbono = valorAbono;
            EstadoAbono = estadoAbono;
            IdMensualidad = idMensualidad;
        }
    }
}
