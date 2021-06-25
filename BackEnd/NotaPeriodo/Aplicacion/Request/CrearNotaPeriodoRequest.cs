namespace BackEnd.NotaPeriodo.Aplicacion.Request
{
    public class CrearNotaPeriodoRequest
    {
        public int Id { get; set; }
        public double Nota { get; set; }
        public string Observacion { get; set; }
        public int IdPeriodo { get; set; }
        public int IdMateria { get; set; }
    }
    public class CrearNotaPeriodoResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Curso Creado Exitosamente");
        }
    }
}
