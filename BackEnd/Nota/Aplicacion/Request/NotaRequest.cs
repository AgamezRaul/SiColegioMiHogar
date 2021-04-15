using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Nota.Aplicacion.Request
{
    public class NotaRequest
    {
        public string Descripcion { get; set; }
        public double NotaAlumno { get; set; }
        public int IdEstudiante { get; set; }
        public int IdMateria { get; set; }
        public int IdPeriodo { get; set; }
    }
}
