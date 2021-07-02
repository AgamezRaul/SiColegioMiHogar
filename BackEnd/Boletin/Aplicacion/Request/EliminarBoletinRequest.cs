namespace BackEnd.Boletin.Aplicacion.Request
{
    public class EliminarBoletinRequest
    {
        public int IdBoletin { get; set; }
    }
    public class EliminarBoletinResponse
    {
        public EliminarBoletinResponse(string message)
        {
            Message = message;
        }
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Boletin Eliminado Exitosamente");
        }
    }
}
