namespace BackEnd.PreMatricula.Aplicacion.Request
{
    public class ActualizarPreMatriculaRequest
    {
        public int id { get; set; }
        public string Estado { get; set; }

    }
    public class ActualizarPreMatriculaResponse
    {
        public ActualizarPreMatriculaResponse(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("PreMatricula Actualizada Exitosamente");
        }
    }
}
