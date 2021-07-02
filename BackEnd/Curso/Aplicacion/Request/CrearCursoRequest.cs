namespace BackEnd.Curso.Aplicacion.Request
{
    public class CrearCursoRequest
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int maxEstudiantes { get; set; }
        public int idDirectorDocente { get; set; }
        public string Letra { get; set; }
    }
    public class CrearCursoResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Curso Creado Exitosamente");
        }
    }
}