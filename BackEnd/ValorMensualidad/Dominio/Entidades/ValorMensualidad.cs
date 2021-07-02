using BackEnd.Base;
using System;

namespace BackEnd.ValorMensualidad.Dominio
{
    public class ValorMensualidad : Entity<int>
    {
        public DateTime Fecha { get; set; }
        public int Año { get; set; }
        public Double PrecioMensualidad { get; set; }
        public int IdGrado { get; set; }
        public ValorMensualidad(DateTime fecha, int año, double precioMensualidad, int idGrado)
        {
            Fecha = fecha;
            Año = año;
            PrecioMensualidad = precioMensualidad;
            IdGrado = idGrado;
        }

    }
}
