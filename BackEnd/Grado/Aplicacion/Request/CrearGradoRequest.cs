using System;
using System.Collections.Generic;

namespace BackEnd.Grado.Aplicacion.Request
{
    public class CrearGradoRequest
    {
        public int id { get; set; }
        public String Nombre { get; set; }
        public IReadOnlyList<string> CanCrear(CrearGradoRequest grado)
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(grado.Nombre.ToString()))
                errors.Add("Campo Nombre del Grado vacio");
            return errors;

        }
    }
    public class CrearGradoResponse
    {
        public CrearGradoResponse(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Grado Creado Exitosamente");
        }
    }
}
