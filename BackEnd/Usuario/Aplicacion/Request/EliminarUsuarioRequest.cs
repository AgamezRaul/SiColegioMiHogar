namespace BackEnd.Usuario.Aplicacion.Request
{
    public class EliminarUsuarioRequest
    {
        public string Correo { get; set; }
    }
    public class EliminarUsuarioResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Usuario eliminado exitosamente");
        }
    }
}
