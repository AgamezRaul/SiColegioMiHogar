namespace BackEnd.Actividad
{
    public class ActualizarActividadRequest
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public double Porcentaje { get; set; }
        public int IdMateria { get; set; }
        public int IdPeriodo { get; set; }
    }

    public class ActualizarActividadResponse
    {
        public ActualizarActividadResponse(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
        public bool IsOk()
        {
            return this.Message.Equals("Actividad actualizada correctamente");
        }
    }
}
