namespace BackEnd.Mensualidad.Aplicacion.Request
{
    public class EliminarMensualidadRequest
    {
        public int IdMensualidad { get; set; }
    }
    public class EliminarMensualidadResponse
    {
        public EliminarMensualidadResponse(string message)
        {
            Message = message;
        }
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Mensualidad Eliminada Exitosamente");
        }
    }
}
