namespace BackEnd.Mensualidad.Aplicacion.Request
{
    public class ActualizarMensualidadRequest
    {

        public int id { get; set; }
        public double Deuda { get; set; }
        public string Estado { get => EstadoMensualiad(Deuda); }
        public string EstadoMensualiad(double debe)
        {
            if (debe > 0) { return "Mora"; }
            else { return "Paz y Salvo"; }
        }
    }

    public class ActualizarMensualidadResponse
    {
        public ActualizarMensualidadResponse(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Mensualidad Actualizada Exitosamente");
        }
    }
}
