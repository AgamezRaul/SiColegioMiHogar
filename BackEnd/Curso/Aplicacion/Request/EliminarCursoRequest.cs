using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Curso.Aplicacion.Request
{
    public class EliminarCursoRequest
    {
        public int IdCurso { get; set; }
    }
    public class EliminarCursoResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Curso Eliminado Exitosamente");
        }
    }
}
