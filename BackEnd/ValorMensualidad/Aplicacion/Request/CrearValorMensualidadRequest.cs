using System;
using System.Collections.Generic;

namespace BackEnd.ValorMensualidad.Aplicacion.Request
{
    public class CrearValorMensualidadRequest
    {
        public int id { get; set; }
        public DateTime Fecha { get; set; }
        public int Año { get => Fecha.Year; }
        public Double PrecioMensualidad { get; set; }
        public int IdGrado { get; set; }
        public IReadOnlyList<string> CanCrear(CrearValorMensualidadRequest valorMensulidad)
        {
            var errors = new List<string>();
            if (string.IsNullOrEmpty(valorMensulidad.Fecha.ToString())) 
            errors.Add("Campo Fecha  vacio");
            if (valorMensulidad.PrecioMensualidad == 0)
                errors.Add("Campo  Valor de la mensualidad vacio");
            if (valorMensulidad.IdGrado == 0)
                errors.Add("Campo identificacion del grado Vacio");
            return errors;
        }
    }
    public class CrearValorMensualidadResponse
    {
        public CrearValorMensualidadResponse(string message)
        {
            Message = message;
        }
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Valor Mensualidad Creado Exitosamente");
        }
    }
}
