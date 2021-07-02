namespace BackEnd.Actividad.Aplicacion
{
    public class EliminarActividadResponse
    {
        public EliminarActividadResponse(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
        public bool IsOk()
        {
            return this.Message.Equals("Actividad eliminada exitosamente");
        }
    }
}
