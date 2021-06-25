namespace BackEnd.Docente.Aplicacion.Request
{
    public class ActualizarDocenteRequest
    {
        public int id { get; set; }
        public string NombreCompleto { get; set; }
        public string NumTarjetaProf { get; set; }
        public string Cedula { get; set; }
        public string Celular { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
    }
    public class ActualizarDocenteResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Docente actualizado exitosamente");
        }
    }
}
