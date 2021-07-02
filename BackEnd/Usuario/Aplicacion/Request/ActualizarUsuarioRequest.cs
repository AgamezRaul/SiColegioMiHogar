namespace BackEnd.Usuario.Aplicacion.Request
{
    public class ActualizarUsuarioRequest
    {
        public int id { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public string TipoUsuario { get; set; }
    }
    public class ActualizarUsuarioResponse
    {
        public ActualizarUsuarioResponse(string message)
        {
            Message = message;
        }
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Usuario Actualizado Exitosamente");
        }
    }
}
