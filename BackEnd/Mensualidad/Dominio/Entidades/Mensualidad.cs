using BackEnd.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Mensualidad.Dominio
{
    public class Mensualidad : Entity<int>
    {
        

        public int Mes { get; set; }
        public int DiaPago { get; set; }
        public DateTime FechaPago { get; set; }
        public double ValorMensualidad { get; set; }
        public double DescuentoMensualidad { get; set; }
        public double Abono { get; set; }
        public double Deuda { get; set; }
        public string Estado { get; set; }
        public int IdMatricula { get; set; }
        public double TotalMensualidad { get; set; }
        public Mensualidad(int mes, int diaPago, DateTime fechaPago, double valorMensualidad, double descuentoMensualidad, double abono, double deuda, string estado, int idMatricula, double totalMensualidad)
        {
            Mes = mes;
            DiaPago = diaPago;
            FechaPago = fechaPago;
            ValorMensualidad = valorMensualidad;
            DescuentoMensualidad = descuentoMensualidad;
            Abono = abono;
            Deuda = deuda;
            Estado = estado;
            IdMatricula = idMatricula;
            TotalMensualidad = totalMensualidad;
        }
    }
}
