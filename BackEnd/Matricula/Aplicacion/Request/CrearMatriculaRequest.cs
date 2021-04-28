using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Matricula.Aplicacion.Request
{
   public class CrearMatriculaRequest
    {
        public int id { get; set; }
        public DateTime FecConfirmacion { get => DateTime.Now.Date; }
        public int IdPreMatricula { get; set; }

        public IReadOnlyList<string> CanCrear(CrearMatriculaRequest matricula)
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(matricula.FecConfirmacion.ToString()))
                errors.Add("Campo Fecha de confirmacion vacio");
            if (matricula.IdPreMatricula == 0)
                errors.Add("Campo identiificacion  de Pre-matricula  vacio");
            return errors;
        }

    }
    public class CrearMatriculaResponse
    {
        public CrearMatriculaResponse(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Matricula Creada Exitosamente");
        }
    }
}
