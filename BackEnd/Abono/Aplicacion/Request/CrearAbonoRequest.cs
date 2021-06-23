using System;
using System.Collections.Generic;

namespace BackEnd.Abono.Aplicacion.Request
{
    public class CrearAbonoRequest
    {
        public int id { get; set; }
        public int Mes { get=>FechaPago.Month; }
        public DateTime FechaPago { get => DateTime.Now; }
        public Double ValorAbono { get; set; }
        public String EstadoAbono { get => "Correcto"; }
        public int IdMensualidad { get; set; }
        public IReadOnlyList<string> CanCrear(CrearAbonoRequest abono)
        {
            var errors = new List<string>();
            if (abono.ValorAbono == 0)
                errors.Add("Campo  Valor del abono vacio");
            if (abono.IdMensualidad == 0)
                errors.Add("Campo idMensualidad Vacio");
            return errors;
        }
    }
    public class CrearAbonoResponse
    {
        public CrearAbonoResponse(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Abono Creado Exitosamente");
        }
    }
}
