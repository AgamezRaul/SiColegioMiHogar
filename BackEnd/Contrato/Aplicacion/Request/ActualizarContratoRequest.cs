using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Contrato.Aplicacion.Request
{
    public class ActualizarContratoRequest
    {
        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public double Sueldo { get; set; }
        public int IdDocente { get; set; }
    }
    public class ActualizarContratoResponse
    {
        public ActualizarContratoResponse(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
        public bool IsOk()
        {
            return this.Message.Equals("El  contrato del docente  ha  sido actualizado exitosamente");
        }
    }
}
