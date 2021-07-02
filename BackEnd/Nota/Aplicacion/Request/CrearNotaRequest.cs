using System;

namespace BackEnd.Nota.Aplicacion.Request
{
    public class CrearNotaRequest
    {
        public int Id { get; set; }
        public string NomEstudiante { get; set; }
        public double NotaAlumno { get; set; }
        public DateTime FechaNota { get => DateTime.Now.Date; }
        public int IdActividad { get; set; }
        public int IdEstudiante { get; set; }
    }
    public class CrearNotaResponse
    {
        public string Message { get; set; }

        public CrearNotaResponse(string message)
        {
            Message = message;
        }

        public bool isOk()
        {
            return this.Message.Equals("Notas Registradas Exitosamente");
        }
    }
}
