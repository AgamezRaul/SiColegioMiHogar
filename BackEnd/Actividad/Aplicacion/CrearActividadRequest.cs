using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Actividad.Aplicacion
{
    public class CrearActividadRequest
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public double Porcentaje { get; set; }
        public int IdMateria { get; set; }
        public int IdPeriodo { get; set; }

        public IReadOnlyList<string> CanCrear(CrearActividadRequest actividad)
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(actividad.Descripcion))
                errors.Add("Campo Fecha de Prematricula vacio");
            if (string.IsNullOrEmpty(actividad.Porcentaje.ToString()))
                errors.Add("Campo Estado de prematricula vacio");
            if (string.IsNullOrEmpty(actividad.IdMateria.ToString()))
                errors.Add("Campo Identificacion estudiante vacio");
            if (string.IsNullOrEmpty(actividad.IdPeriodo.ToString()))
                errors.Add("Campo Estado de prematricula vacio");
            return errors;
        }
    }
    public class CrearActividadResponse
    {
        public CrearActividadResponse(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
        public bool IsOk()
        {
            return this.Message.Equals("Actividad creada exitosamente");
        }
    }
}
