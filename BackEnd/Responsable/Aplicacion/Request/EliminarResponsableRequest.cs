namespace BackEnd.Responsable.Aplicacion.Request
{
    public class EliminarResponsableRequest
    {
        public int UsuarioId { get; set; }
    }
    public class EliminarResponsableResponse
    {
        public EliminarResponsableResponse(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Responsable Eliminado Exitosamente");
        }
    }
}
