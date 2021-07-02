namespace BackEnd.PreMatricula.Aplicacion.Request
{
    public class EliminarPreMatriculaRequest
    {
        public int UsuarioId { get; set; }
    }
    public class EliminarPreMatriculaResponse
    {
        public EliminarPreMatriculaResponse(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("PreMatricula Eliminado Exitosamente");
        }
    }
}
