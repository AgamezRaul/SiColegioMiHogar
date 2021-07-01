namespace BackEnd.Matricula.Aplicacion.Request
{
    public class EliminarMatriculaRequest
    {
        public int Id { get; set; }
    }
    public class EliminarMatriculaResponse
    {
        public EliminarMatriculaResponse(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Matricula Eliminado Exitosamente");
        }
    }
}
