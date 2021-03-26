using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Usuario.Aplicacion.Request
{
    public class CrearUsuarioRequest
    {
        public int id { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public string NomUsuario { get; set; }
        public string TipoUsuario { get => "Responsable"; }
    }
    public class CrearUsuarioResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Usuario Creado Exitosamente");
        }
    }
}
