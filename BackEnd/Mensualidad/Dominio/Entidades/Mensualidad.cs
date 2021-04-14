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
       

        public IReadOnlyList<string> CanCrear(Mensualidad mensualidad)
        {
            var errors = new List<string>();

            if (mensualidad.Mes == 0)
                errors.Add("Campo Mes en que se realiza el pago vacio");
            if (mensualidad.DiaPago == 0)
                errors.Add("Campo dia de pago en el que se acordo pagar la mensualidad  vacio");
            if (string.IsNullOrEmpty(mensualidad.FechaPago.ToString()))
                errors.Add("Campo Fecha de Pago vacio");
            if (mensualidad.ValorMensualidad == 0)
                errors.Add("Campo  Valor de Mensualidad vacio");
            if (mensualidad.DescuentoMensualidad < 0)
                errors.Add("Campo Descuento Mensualidad no debe ser negativo");
            if (mensualidad.Abono == 0)
                errors.Add("Campo Abono vacio");
            if (string.IsNullOrEmpty(mensualidad.Estado))
                errors.Add("Campo Estado de mensualidad vacio");
            if (mensualidad.IdMatricula == 0)
                errors.Add("Campo identiificacion  de matricula  vacio");
            return errors;
        }

    }
}
