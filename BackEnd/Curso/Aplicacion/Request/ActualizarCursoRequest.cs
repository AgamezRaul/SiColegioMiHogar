using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Curso.Aplicacion.Request
{
    public class ActualizarCursoRequest
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int maxEstudiantes { get; set; }
        public int idDirectorDocente { get; set; }
    }
    public class ActualizarCursoResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Curso Actualizado Exitosamente");
        }
    }
}