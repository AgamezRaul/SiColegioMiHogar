namespace BackEnd.Grado.Aplicacion.Request
{
    public class EliminarGradoRequest
    {
        public int id { get; set; }
    }
    public class EliminarGradoResponse
    {
        public EliminarGradoResponse(string message)
        {
            Message = message;
        }
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Grado Eliminado Exitosamente");
        }
    }
}
