using System;

namespace BackEnd.Estudiante.Aplicacion.Request
{
    public class CrearEstudianteRequest
    {
        public int id { get; set; }
        public string IdeEstudiante { get; set; }
        public string NomEstudiante { get; set; }
        public DateTime FecNacimiento { get; set; }
        public string LugNacimiento { get; set; }
        public string LugExpedicion { get; set; }
        public string InsProcedencia { get; set; }
        public string DirResidencia { get; set; }
        public string CelEstudiante { get; set; }
        public string TipSangre { get; set; }
        public string GradoEstudiante { get; set; }
        public string Eps { get; set; }
        public string Correo { get; set; }
        public string Sexo { get; set; }
        public string TipoDocumento { get; set; }
        public string TelEstudiante { get; set; }
        public int IdUsuario { get; set; }
    }
    public class CrearEstudianteResponse
    {
        public CrearEstudianteResponse(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Estudiante Creado Exitosamente");
        }
    }
}
