namespace BackEnd.Contrato.Aplicacion.Request
{
    public class EliminarContratoRequest
    {
        public int IdDocente { get; set; }
    }

    public class EliminarContratoResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Contrato eliminado exitosamente");
        }
    }

}
