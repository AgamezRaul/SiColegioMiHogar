using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Nota.Aplicacion.Request
{
    public class CrearNotaRequest
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public double NotaAlumno{ get; set; }
        public DateTime FechaNota { get=>DateTime.Now.Date; }
        public int IdEstudiante { get; set; }
        public int IdMateria { get; set; }
        public int IdPeriodo { get; set; }
    }
    public class CrearNotaResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Nota Registrada Exitosamente");
        }
    }
}
