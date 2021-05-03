using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Contrato.Aplicacion.Request
{
    public class CrearContratoRequest
    {
        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public double Sueldo { get; set; }
        public int IdDocente { get; set; }
        public IReadOnlyList<string> CanCrear(CrearContratoRequest contrato)
        {
            var errors = new List<string>();
            if (string.IsNullOrEmpty(contrato.FechaInicio.ToString()))
                errors.Add("Campo Fecha Inicio vacio");
            if (string.IsNullOrEmpty(contrato.FechaFin.ToString()))
                errors.Add("Campo Fecha Fin vacio");
            if (contrato.Sueldo == 0)
                errors.Add("Campo Sueldo vacio");
            if (contrato.IdDocente == 0)
                errors.Add("Campo IdDocente vacio");
            return errors;
        }
    }
    public class CrearContratoResponse
    {
        public CrearContratoResponse(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
        public bool IsOk()
        {
            return this.Message.Equals("Contrato Creado Exitosamente");
        }
    }
}
